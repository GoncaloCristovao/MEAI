function n_mec = tp2_109041()
% As características gerais das imagens são as seguintes:
% - As imagens são a cores.
% - As imagens podem estar rodadas e a zona do fundo fora do envelope será em nível de cinzento.
% - As imagens contêm 4 linhas de texto em posição variável.
% - As imagens podem conter um selo que poderá ter uma posição e orientação variável.
% - Os envelopes podem ter cores diversas, como presente nos exemplos fornecidos.
% - Nos envelopes pode haver outros elementos acessórios (símbolos, carimbos, etc.). 
% - No final, retorna o nº mecanográfico 109041 e gera um ficheiro .txt.
    
    close all; clc;
    n_mec = 109041;
    
    % Adicionar path para as imagens 
    addpath('../');      
    
    % Ler todas as imagens 
    lista_Img = dir('../svpi2026_TP2_img_*.png');
    
    if isempty(lista_Img)
        error('Nenhuma imagem encontrada na pasta anterior (../)!');
    end
    
    % Criar o ficheiro de texto para escrita
    nome_ficheiro = sprintf('tp2_%d.txt', n_mec);
    fid = fopen(nome_ficheiro, 'w');
    if fid == -1
        error('Não foi possível criar o ficheiro de resultados.');
    end
    
    % Carregar o modelo da rede neural
    try
        load('mnist_svpi2026_tp2_109041.mat', 'net'); 
    catch
        fclose(fid);
        error('Ficheiro do modelo mnist_svpi2026_tp2_109041.mat não encontrado!');
    end
        
    for n = 1:length(lista_Img)
        nome = lista_Img(n).name;
        
        % Extrair identificadores do nome (svpi2026_TP2_img_MMM_NN.png)
        num_serie = str2double(nome(18:20));
        num_img = str2double(nome(22:23));
        
        % Iniciar com valores por defeito em caso de erro
        stampN = 0; numNam = 0; numAdd = 0; numDoor = 0; D = zeros(1, 8);
        
        try
            caminho_completo = fullfile(lista_Img(n).folder, nome);
            Img = imread(caminho_completo);
            
            % -------------------------------------------------------------
            % Etapa 1 e 2: Segmentação e rotação do envelope
            ImgGray = rgb2gray(Img);
            BW_edges = edge(ImgGray, 'canny'); 
            BW_mask = imclose(BW_edges, strel('square', 50)); 
            BW_mask = imfill(BW_mask, 'holes'); 
            
            stats_all = regionprops(BW_mask, 'Area', 'Orientation', 'BoundingBox');
            if isempty(stats_all)
                area_max = 0; 
            else
                [area_max, idx_max] = max([stats_all.Area]);
                envelope_candidato = stats_all(idx_max);
            end
            
            area_total_img = numel(ImgGray);
            if area_max > (area_total_img * 0.30) && area_max < (area_total_img * 0.95)
                angulo = envelope_candidato.Orientation;
                ImgRot = imrotate(Img, -angulo, 'bilinear', 'loose');
                MaskRot = imrotate(BW_mask, -angulo, 'bilinear', 'loose');
                stats_rot = regionprops(bwareafilt(MaskRot, 1), 'BoundingBox');
                bbox = stats_rot.BoundingBox;
                m = 0.035; 
                InnerBox = [bbox(1)+bbox(3)*m, bbox(2)+bbox(4)*m, bbox(3)*(1-2*m), bbox(4)*(1-2*m)];
                EnvelopeLimpo = imcrop(ImgRot, InnerBox);
            else
                EnvelopeLimpo = Img;
            end
            
            [altL, largL, ~] = size(EnvelopeLimpo);
            
            % -------------------------------------------------------------
            % Estapa 3: Selo 
            roi_selo_w = round(largL * 0.50); 
            roi_selo_h = round(altL * 0.55); 
            CantoSelo = imcrop(EnvelopeLimpo, ...
            [largL - roi_selo_w, 1, roi_selo_w, roi_selo_h]);
            Igray_roi = rgb2gray(CantoSelo);
            melhor_idx = 0; 
            SeloBinFinal = [];
            
            SeloBin = edge(Igray_roi, 'Canny'); 
            SeloBin = imclose(SeloBin, strel('square', 3)); 
            SeloBin = imfill(SeloBin, 'holes'); 
            stats_selo = regionprops(bwareaopen(SeloBin, 800), 'Area', 'Solidity', 'BoundingBox', 'PixelIdxList', 'Eccentricity');
            melhor_idx = filtrarSelo(stats_selo); 
            if ~isempty(melhor_idx), SeloBinFinal = SeloBin; end
            
            if isempty(melhor_idx)
                SeloBin = edge(Igray_roi, 'Canny'); 
                SeloBin = imclose(SeloBin, strel('square', 12)); 
                SeloBin = imfill(SeloBin, 'holes'); 
                stats_selo = regionprops(bwareaopen(SeloBin, 1000), 'Area', 'Solidity', 'BoundingBox', 'PixelIdxList', 'Eccentricity');
                melhor_idx = filtrarSelo(stats_selo); 
                if ~isempty(melhor_idx), SeloBinFinal = SeloBin; end
            end
            
            if isempty(melhor_idx)
                SeloBin = imbinarize(Igray_roi, 'adaptive', 'ForegroundPolarity', 'dark', 'Sensitivity', 0.45);
                SeloBin = imfill(bwareaopen(SeloBin, 1200), 'holes'); 
                stats_selo = regionprops(SeloBin, 'Area', 'Solidity', 'BoundingBox', 'PixelIdxList', 'Eccentricity');
                melhor_idx = filtrarSelo(stats_selo); 
                if ~isempty(melhor_idx), SeloBinFinal = SeloBin; end
            end
            
            if ~isempty(melhor_idx)
                box_selo = stats_selo(melhor_idx).BoundingBox;
                MascaraIsolada = false(size(SeloBinFinal));
                MascaraIsolada(stats_selo(melhor_idx).PixelIdxList) = true;
                R_chan = CantoSelo(:,:,1); 
                mediaR = mean(R_chan(MascaraIsolada));
                G_chan = CantoSelo(:,:,2); 
                mediaG = mean(G_chan(MascaraIsolada));
                B_chan = CantoSelo(:,:,3); 
                mediaB = mean(B_chan(MascaraIsolada));
                stampN = identificarSelo(stats_selo(melhor_idx).Eccentricity, stats_selo(melhor_idx).Solidity, ...
                                         mediaR, mediaG, mediaB, box_selo(3)/box_selo(4));
            end
            
            % -------------------------------------------------------------
            % Etapa 4: Processamento de Texto e Porta
            roi_txt_x = round(largL * 0.20); 
            roi_txt_y = round(altL * 0.35);
            roi_txt_w = round(largL * 0.75); 
            roi_txt_h = round(altL * 0.60);
            ZonaTexto = imcrop(EnvelopeLimpo, [roi_txt_x, roi_txt_y, roi_txt_w, roi_txt_h]);
            TxtGray = max(ZonaTexto, [], 3); 
            
            TxtBin = ~imbinarize(TxtGray, 'adaptive', 'ForegroundPolarity', 'dark', 'Sensitivity', 0.45); 
            TxtBin = bwareaopen(TxtBin, 40);
            
            se_palavra = strel('rectangle', [3, 40]); 
            PalavrasMask = imdilate(TxtBin, se_palavra);
            PalavrasMask = bwareaopen(PalavrasMask, 300); 
            
            stats_txt_bruto = regionprops(PalavrasMask, 'Centroid', 'BoundingBox');
            [h_txt, w_txt] = size(TxtBin);
            
            idx_validos = [];
            for k = 1:length(stats_txt_bruto)
                box = stats_txt_bruto(k).BoundingBox; largura = box(3); altura = box(4); prop = largura / altura;
                centro_x = stats_txt_bruto(k).Centroid(1); centro_y = stats_txt_bruto(k).Centroid(2);
                if altura > 15 && altura < 45 && prop > 2.5
                    zona_selo = (centro_x > w_txt * 0.70 && centro_y < h_txt * 0.30);
                    zona_fundo = (centro_y > h_txt * 0.85);
                    if ~zona_selo && ~zona_fundo
                        idx_validos = [idx_validos, k]; 
                    end
                end
            end
            stats_txt = stats_txt_bruto(idx_validos);
            
            if ~isempty(stats_txt)
                centroides = cat(1, stats_txt.Centroid);
                [~, ordem_Y] = sort(centroides(:, 2));
                stats_linhas_raw = stats_txt(ordem_Y);
                
                LIMIAR_Y = 25;
                grupos = {};
                grupo_atual = stats_linhas_raw(1);
                
                for k = 2:length(stats_linhas_raw)
                    diff_y = abs(stats_linhas_raw(k).Centroid(2) - grupo_atual.Centroid(2));
                    if diff_y < LIMIAR_Y
                        x1 = min(grupo_atual.BoundingBox(1), stats_linhas_raw(k).BoundingBox(1));
                        y1 = min(grupo_atual.BoundingBox(2), stats_linhas_raw(k).BoundingBox(2));
                        x2 = max(grupo_atual.BoundingBox(1)+grupo_atual.BoundingBox(3), ...
                                 stats_linhas_raw(k).BoundingBox(1)+stats_linhas_raw(k).BoundingBox(3));
                        y2 = max(grupo_atual.BoundingBox(2)+grupo_atual.BoundingBox(4), ...
                                 stats_linhas_raw(k).BoundingBox(2)+stats_linhas_raw(k).BoundingBox(4));
                        grupo_atual.BoundingBox = [x1, y1, x2-x1, y2-y1];
                        grupo_atual.Centroid    = [(x1+x2)/2, (y1+y2)/2];
                    else
                        grupos{end+1} = grupo_atual;
                        grupo_atual = stats_linhas_raw(k);
                    end
                end
                grupos{end+1} = grupo_atual;
                stats_linhas = [grupos{:}];
                
                % Linha 1: Nome
                if length(stats_linhas) >= 1
                    box_nome = stats_linhas(1).BoundingBox;
                    TxtBin_Nome = imcrop(TxtBin, box_nome);
                    PalavrasNomeMask = imdilate(TxtBin_Nome, strel('rectangle', [3, 12]));
                    PalavrasNomeMask = bwareaopen(PalavrasNomeMask, 30); 
                    stats_palavras_nome = regionprops(PalavrasNomeMask, 'BoundingBox');
                    numNam = length(stats_palavras_nome);
                end
                
                % Linha 2: Morada e Porta
                if length(stats_linhas) >= 2
                    box_morada = stats_linhas(2).BoundingBox;
                    TxtBin_Morada = imcrop(TxtBin, box_morada);
                    PalavrasMoradaMask = imdilate(TxtBin_Morada, strel('rectangle', [3, 7]));
                    PalavrasMoradaMask = bwareaopen(PalavrasMoradaMask, 30); 
                    stats_palavras_morada = regionprops(PalavrasMoradaMask, 'BoundingBox', 'Centroid');
                    
                    if ~isempty(stats_palavras_morada)
                        centroides_m = cat(1, stats_palavras_morada.Centroid);
                        [~, ordem_X] = sort(centroides_m(:, 1));
                        stats_morada_ordenada = stats_palavras_morada(ordem_X);
                        
                        box_porta_local = stats_morada_ordenada(end).BoundingBox;
                        numAdd = length(stats_morada_ordenada) - 1;
                        
                        for p_idx = length(stats_morada_ordenada)-1 : -1 : 1
                            box_prev  = stats_morada_ordenada(p_idx).BoundingBox;
                            gap       = box_porta_local(1) - (box_prev(1) + box_prev(3));
                            prop_prev = box_prev(3) / box_prev(4);
                            if gap < 25 && prop_prev >= 0.05 && prop_prev <= 1.2
                                min_x = box_prev(1);
                                min_y = min(box_porta_local(2), box_prev(2));
                                max_x = box_porta_local(1) + box_porta_local(3);
                                max_y = max(box_porta_local(2)+box_porta_local(4), box_prev(2)+box_prev(4));
                                box_porta_local = [min_x, min_y, max_x-min_x, max_y-min_y];
                                numAdd = p_idx - 1;
                            else
                                break;
                            end
                        end
                        
                        box_porta_global = [box_porta_local(1) + box_morada(1), box_porta_local(2) + box_morada(2), box_porta_local(3), box_porta_local(4)];
                        TxtBin_Porta = imcrop(TxtBin, box_porta_global);
                        
                        stats_lixo = regionprops(TxtBin_Porta, 'Area', 'Centroid', 'PixelIdxList');
                        h_porta = size(TxtBin_Porta, 1);
                        for p = 1:length(stats_lixo)
                            if stats_lixo(p).Area < 30 && stats_lixo(p).Centroid(2) > h_porta * 0.60
                                TxtBin_Porta(stats_lixo(p).PixelIdxList) = 0;
                            end
                        end
                        TxtBin_Porta = bwareaopen(TxtBin_Porta, 5);
                        stats_digitos_porta = regionprops(TxtBin_Porta, 'BoundingBox', 'Centroid', 'Image');
                        
                        if ~isempty(stats_digitos_porta)
                            cent_d = cat(1, stats_digitos_porta.Centroid);
                            [~, ordem_d] = sort(cent_d(:, 1));
                            digitos_ordenados = stats_digitos_porta(ordem_d);
                            vetor_numeros = []; 
                            for d = 1:length(digitos_ordenados)
                                n_extra = segmentarELer(digitos_ordenados(d).Image);
                                vetor_numeros = [vetor_numeros, n_extra];
                            end
                            if ~isempty(vetor_numeros)
                                numDoor = str2double(sprintf('%d', vetor_numeros)); 
                            end
                        end
                    end
                end
                
                % Linha 3: Código Postal
                if length(stats_linhas) >= 3
                    box_cp = stats_linhas(3).BoundingBox;
                    box_cp = [box_cp(1)-2, box_cp(2)-2, box_cp(3)+4, box_cp(4)+4];
                    TxtBin_CP = imcrop(TxtBin, box_cp);
             
                    TxtBin_CP_Limp = bwareaopen(TxtBin_CP, 8);
                    
                    % Máscara para detetar digitos
                    TxtBin_CP_Mascara = imclose(TxtBin_CP_Limp, strel('rectangle', [8, 3]));
                    
                    % Encontrar as 8 caixas 
                    TxtBin_8 = bwareafilt(TxtBin_CP_Mascara, 8);
                    stats_detect = regionprops(TxtBin_8, 'BoundingBox');
                
                    if length(stats_detect) == 8
                        bbs = cat(1, stats_detect.BoundingBox);
                        [~, ord_x] = sort(bbs(:, 1));
                        stats_detect = stats_detect(ord_x);
                
                        for d = 1:8
                            box_d = stats_detect(d).BoundingBox;                        
                            img_digit = imcrop(TxtBin_CP_Limp, box_d);                           
                            [D(d), ~] = classificarDigitoMNIST(img_digit, net);
                        end
                    end
                end
            end
        catch me
            fprintf('  -> Aviso: Imagem %s processada com erro interno (%s). Preenchida com zeros.\n', nome, me.message);
        end
        
        % Escrever os dados no ficheiro txt
        fprintf(fid, '%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d\n', ...
            n_mec, num_serie, num_img, stampN, numNam, numAdd, numDoor, ...
            D(1), D(2), D(3), D(4), D(5), D(6), D(7), D(8));
    end
    
    fclose(fid);
end

% Função do Código Postal
function [digito, img_28x28] = classificarDigitoMNIST(img_bin, net)
    img_bin = logical(img_bin);
    [rows, cols] = find(img_bin);
    
    if isempty(rows)
        digito = 0; img_28x28 = zeros(28,28,'single'); return;
    end
    
    % Crop da tinta exata
    img_crop = img_bin(min(rows):max(rows), min(cols):max(cols));
    
    % Medir a espessura e furos
    stats = regionprops(img_crop, 'Area', 'Perimeter', 'EulerNumber');
    
    if ~isempty(stats)
        area_tinta = stats(1).Area;
        perimetro = stats(1).Perimeter;
        
        if perimetro > 0
            espessura_pixeis = area_tinta / (perimetro / 2);
        else
            espessura_pixeis = 1; 
        end
        
        tem_furos = (1 - stats(1).EulerNumber) > 0;
        
        % Só dilatamos se for mesmo muito fino (< 1.6)
        if espessura_pixeis < 1.6 
            if ~tem_furos
                img_crop = imdilate(img_crop, strel('disk', 1));
            else
                img_crop = imdilate(img_crop, strel('square', 1));
            end
        end
    end
    
    % Resize
    [h, w] = size(img_crop);
    escala = 20 / max(h, w);
    
    if escala >= 1
        img_20 = imresize(double(img_crop), escala, 'nearest');
        img_20 = imgaussfilt(img_20, 0.4, 'FilterSize', 3);
    else
        img_20 = imresize(double(img_crop), escala, 'bilinear');
    end
    
    max_val = max(img_20(:));
    if max_val > 0
        img_20 = img_20 / max_val;
    end
    img_20 = img_20 .^ 0.8; 
    
    % Centrar o digito na matriz
    img_28x28 = zeros(28, 28, 'single');
    
    [Y, X] = ndgrid(1:size(img_20,1), 1:size(img_20,2));
    massa_total = sum(img_20(:));
    
    if massa_total > 0
        % Calcular o centro de gravidade da tinta
        centro_x = sum(X(:) .* img_20(:)) / massa_total;
        centro_y = sum(Y(:) .* img_20(:)) / massa_total;
        
        % Calcular o deslocamento para o centro exato da matriz (14.5, 14.5)
        shift_x = round(14.5 - centro_x);
        shift_y = round(14.5 - centro_y);
        
        % Colar a imagem respeitando os limites
        for r = 1:size(img_20, 1)
            for c = 1:size(img_20, 2)
                out_r = r + shift_y;
                out_c = c + shift_x;
                if out_r >= 1 && out_r <= 28 && out_c >= 1 && out_c <= 28
                    img_28x28(out_r, out_c) = img_20(r, c);
                end
            end
        end
    end

    if nargin < 2 || isempty(net), digito = -1; return; end
    try
        pred = classify(net, img_28x28);
        digito = str2double(char(pred));
    catch
        digito = -1;
    end
end

% Funções do ID do selo 
function idx = filtrarSelo(stats)
    idx = []; maior_score = 0; 
    if isempty(stats), return; end
    for i = 1:length(stats)
        area = stats(i).Area; sol = stats(i).Solidity; exc = stats(i).Eccentricity;
        box = stats(i).BoundingBox; largura = box(3); altura = box(4);
        prop = largura / altura; extent = area / (largura * altura);
        if area > 2000 && largura > 40 && altura > 40 && area < 40000 && ...
           sol > 0.65 && exc < 0.95 && prop >= 0.5 && prop <= 2.0 && extent > 0.45
            score_atual = area * sol;
            if score_atual > maior_score
                maior_score = score_atual;
                idx = i;
            end
        end
    end
end

function id_selo = identificarSelo(exc, sol, R, G, B, proporcao)
    LuzTotal = R + G + B;
    if LuzTotal == 0, LuzTotal = 1; end 
    
    r_norm = (R / LuzTotal) * 255; 
    g_norm = (G / LuzTotal) * 255; 
    b_norm = (B / LuzTotal) * 255;
    
    VetorAtual = [exc * 200, sol * 200, r_norm, g_norm, b_norm];
    
    PadroesOriginais = [
        0.7100, 0.9832, 137.82, 122.55, 117.11;
        0.5708, 0.9815, 182.72, 156.45, 146.79;
        0.7850, 0.9807, 169.24, 152.47, 123.56; 
        0.6145, 0.9746, 159.20, 151.08, 146.30;
        0.4754, 0.9729, 178.09, 168.68, 161.04; 
        0.6067, 0.9874, 182.58, 153.02, 145.50;
        0.4966, 0.9802, 159.72, 165.47, 156.72  
    ];
    
    distancias = zeros(1, 7);
    for i = 1:size(PadroesOriginais, 1)
        L_ref = sum(PadroesOriginais(i, 3:5));
        V_ref = [PadroesOriginais(i, 1)*200, PadroesOriginais(i, 2)*200, (PadroesOriginais(i, 3:5)/L_ref)*255];
        distancias(i) = sqrt(sum((VetorAtual - V_ref).^2));
    end
    
    % Filtros por proporção
    if proporcao > 1.1 
        distancias(3) = Inf; distancias(4) = Inf; 
    elseif proporcao < 0.85 
        distancias([1, 2, 6, 7]) = Inf; 
    end
    
    [~, id_selo] = min(distancias);
    
    if (id_selo == 2 || id_selo == 6)
        % Se a diferença for <= 4.5, é o Selo 6 
        if (g_norm - b_norm) <= 4.5
            id_selo = 6; 
        else
            id_selo = 2; 
        end
    end
end

% Funções do nº Porta 
function vetor = segmentarELer(img_bin)
    stats_cc = regionprops(img_bin, 'BoundingBox', 'Image', 'Centroid');
    if length(stats_cc) > 1
        cents = cat(1, stats_cc.Centroid);
        [~, ord] = sort(cents(:,1));
        vetor = [];
        for i = 1:length(ord)
            v = segmentarELer(stats_cc(ord(i)).Image);
            vetor = [vetor, v];
        end
        return; 
    end
    [alt, larg] = size(img_bin);
    
    if larg > 0.95 * alt && larg > 10
        in_b = round(larg * 0.30);
        fi_b = round(larg * 0.70);
        proj = sum(img_bin(:, in_b:fi_b), 1);
        [~, min_idx] = min(proj);
        corte = in_b + min_idx - 1;
        
        img_e = img_bin(:, 1:corte);
        img_d = img_bin(:, corte+1:end);
        
        largura_util_e = sum(any(img_e, 1));
        largura_util_d = sum(any(img_d, 1));
        
        v_e = []; v_d = [];
        if largura_util_e >= 2
            img_e = bwareaopen(img_e, 5);
            if any(img_e(:)), v_e = segmentarELer(img_e); end
        end
        if largura_util_d >= 2
            img_d = bwareaopen(img_d, 5);
            if any(img_d(:)), v_d = segmentarELer(img_d); end
        end
        vetor = [v_e, v_d];
    else
        img_limpa = bwareafilt(img_bin, 1); 
        s = regionprops(img_limpa, 'EulerNumber', 'Eccentricity', 'Solidity', 'Extent');
        if ~isempty(s)
            furos = 1 - s.EulerNumber;
            n = identificarNumeroPorta(furos, s.Eccentricity, s.Solidity, s.Extent, img_limpa);
            vetor = n;
        else
            vetor = [];
        end
    end
end
function digito = identificarNumeroPorta(furos, exc, sol, ext, img)
    alt = size(img, 1); larg = size(img, 2);
    mY = round(alt / 2); mX = round(larg / 2);
    
    imC = img(1:mY, :); imB = img(mY+1:end, :);
    rY = sum(imC(:)) / max(1, sum(imB(:)));
    rX = sum(sum(img(:, 1:mX))) / max(1, sum(sum(img(:, mX+1:end))));
    
    if (exc > 0.965 && sol > 0.50) || (larg / alt < 0.35)
        digito = 1;
        return; 
    end
    BaseDados = [
        0, 1, 1.0235, 1.1235, 0.9166, 0.6491, 0.4725; 0, 1, 0.9674, 0.8660, 0.9179, 0.7098, 0.5387; 0, 1, 1.0330, 1.0109, 0.9126, 0.7171, 0.5506; 0, 1, 1.0476, 0.8696, 0.9216, 0.6745, 0.4943; 
        1, 0, 1.2000, 1.6667, 0.9897, 0.6423, 0.4490; 1, 0, 1.2439, 1.4865, 0.9876, 0.6715, 0.4694; 1, 0, 1.3778, 0.9107, 0.9844, 0.6369, 0.4777; 1, 0, 1.2826, 1.1000, 0.9860, 0.6863, 0.5357; 
        2, 0, 1.2540, 1.1846, 0.9565, 0.5569, 0.4610; 2, 0, 1.2308, 1.3387, 0.9547, 0.5556, 0.4708; 2, 0, 1.1333, 1.2535, 0.9498, 0.6038, 0.5195; 2, 0, 1.1333, 1.3529, 0.9509, 0.6038, 0.5195; 2, 0, 1.1233, 1.0130, 0.9554, 0.5827, 0.4613; 2, 0, 1.2000, 1.0811, 0.9480, 0.5520, 0.4753;
        3, 0, 1.3333, 0.6771, 0.9399, 0.5833, 0.4792; 3, 0, 1.3548, 0.8250, 0.9416, 0.5594, 0.4506; 3, 0, 1.4062, 0.7500, 0.9436, 0.6235, 0.5185; 3, 0, 1.4918, 0.8313, 0.9419, 0.5914, 0.5118; 3, 0, 1.4262, 0.6818, 0.9411, 0.5421, 0.4568; 3, 0, 1.2222, 0.8391, 0.9400, 0.6061, 0.5195;
        4, 1, 0.8090, 0.5047, 0.9209, 0.7285, 0.4969; 4, 1, 0.8471, 0.5096, 0.9218, 0.7548, 0.4846; 4, 1, 0.7957, 0.5905, 0.9083, 0.7557, 0.4758; 4, 1, 0.9114, 0.5100, 0.9216, 0.7295, 0.4660; 4, 1, 0.8391, 0.4286, 0.9123, 0.7048, 0.4233;  
        5, 0, 1.3167, 1.1719, 0.9444, 0.5430, 0.4357; 5, 0, 1.2903, 0.8205, 0.9365, 0.5399, 0.4226; 5, 0, 1.2941, 0.9747, 0.9406, 0.5693, 0.4483; 5, 0, 1.2059, 1.0833, 0.9451, 0.5474, 0.4310; 5, 0, 1.1029, 1.1029, 0.9467, 0.5586, 0.4643; 5, 1, 1.3088, 0.9873, 0.9420, 0.5548, 0.4511; 5, 0, 1.1739, 1.2727, 0.9388, 0.5792, 0.4870;
        6, 1, 0.5579, 1.1765, 0.9024, 0.6637, 0.4744; 6, 1, 0.6630, 1.1857, 0.9100, 0.6861, 0.5350; 6, 1, 0.6471, 0.9444, 0.9009, 0.6452, 0.4487; 6, 2, 0.6421, 1.0000, 0.8993, 0.6842, 0.5000; 6, 1, 0.7071, 1.3803, 0.8985, 0.6955, 0.4815; 
        7, 0, 1.9744, 0.8710, 0.9571, 0.6105, 0.4296; 7, 0, 1.7727, 1.1786, 0.9624, 0.5865, 0.3961; 7, 0, 1.6304, 1.0167, 0.9597, 0.5762, 0.3601; 7, 0, 1.7111, 0.9062, 0.9570, 0.5648, 0.3631; 7, 0, 2.0000, 0.8621, 0.9605, 0.5838, 0.4000; 7, 0, 1.8810, 1.2000, 0.9626, 0.5990, 0.3929; 7, 0, 1.8095, 0.8730, 0.9594, 0.5842, 0.4370; 7, 0, 1.9730, 0.8644, 0.9635, 0.6011, 0.4074; 7, 0, 1.8684, 0.9123, 0.9609, 0.5266, 0.3539; 7, 0, 1.9000, 0.7059, 0.9546, 0.5859, 0.3906; 
        8, 1, 0.8684, 0.9722, 0.9426, 0.6094, 0.4551; 8, 1, 0.8500, 1.1143, 0.9415, 0.6697, 0.5175; 8, 1, 1.1154, 1.3913, 0.9384, 0.7051, 0.5556; 8, 1, 0.9294, 0.8851, 0.9357, 0.6862, 0.5256; 8, 1, 0.8690, 1.0933, 0.9371, 0.6916, 0.5490; 8, 1, 0.8765, 1.2353, 0.9393, 0.6609, 0.5315; 8, 1, 0.9481, 1.3438, 0.9418, 0.6579, 0.5245; 
        9, 1, 1.7818, 0.9125, 0.8752, 0.6830, 0.4722; 9, 1, 1.3143, 0.9286, 0.8795, 0.6953, 0.5192; 9, 1, 1.2676, 0.9877, 0.8879, 0.6880, 0.4763; 9, 1, 1.6923, 0.7500, 0.8853, 0.6422, 0.4487; 9, 1, 1.2090, 0.8049, 0.8762, 0.6667, 0.4744; 9, 1, 1.4333, 0.7805, 0.8843, 0.6606, 0.4679; 9, 1, 1.3966, 0.8052, 0.8895, 0.6290, 0.4455; 9, 1, 1.1667, 1.1081, 0.8881, 0.7091, 0.5455; 9, 1, 1.4308, 0.9036, 0.8845, 0.6840, 0.4675; 9, 2, 1.2581, 0.9444, 0.8911, 0.6422, 0.4895; 9, 1, 1.5636, 0.8077, 0.8925, 0.6351, 0.4519; 9, 1, 1.2609, 0.8353, 0.8802, 0.6724, 0.5000;
        8, 0, 0.9000, 1.0000, 0.9400, 0.5500, 0.4500; 9, 0, 1.4500, 0.8200, 0.8800, 0.5500, 0.4500; 0, 0, 1.0500, 0.9000, 0.9200, 0.5500, 0.4500; 
    ];
    
    P = [500, 300, 300, 100, 100, 100]; 
    V = [furos, rY, rX, exc, sol, ext] .* P;
    
    dist = zeros(1, size(BaseDados, 1));
    for i = 1:size(BaseDados, 1)
        dist(i) = sqrt(sum((V - BaseDados(i, 2:7).*P).^2));
    end
    
    [dist_ordenadas, indices_ordenados] = sort(dist); 
    
    candidato_1 = BaseDados(indices_ordenados(1), 1);
    dist_1 = dist_ordenadas(1);
    
    candidato_2 = candidato_1;
    dist_2 = dist_1;
    for k = 2:length(indices_ordenados)
        if BaseDados(indices_ordenados(k), 1) ~= candidato_1
            candidato_2 = BaseDados(indices_ordenados(k), 1);
            dist_2 = dist_ordenadas(k);
            break;
        end
    end
    
    LIMIAR_CONFIANCA = 50;
    if dist_1 < LIMIAR_CONFIANCA && dist_2 > dist_1 * 3.0
        digito = candidato_1;
        return; 
    end
    
    digito = candidato_1;
    if (candidato_1 == 1 && candidato_2 == 5) || (candidato_1 == 5 && candidato_2 == 1)
        if (larg / alt) > 0.35, digito = 5; else, digito = 1; end
    end
    if (candidato_1 == 6 && candidato_2 == 8) || (candidato_1 == 8 && candidato_2 == 6)
        if rY < 0.80, digito = 6; else, digito = 8; end
    end
    if (candidato_1 == 5 && candidato_2 == 9) || (candidato_1 == 9 && candidato_2 == 5)
        if furos == 1, digito = 9; else, digito = 5; end
    end
    if (candidato_1 == 3 && candidato_2 == 9) || (candidato_1 == 9 && candidato_2 == 3)
        if furos == 1, digito = 9; else, digito = candidato_1; end
    end
    if (candidato_1 == 2 && candidato_2 == 5) || (candidato_1 == 5 && candidato_2 == 2)
        [~, xc] = find(imC); [~, xb] = find(imB); 
        if mean(xc) > (mean(xb) * 1.10), digito = 2; else, digito = 5; end
    end
    if (candidato_1 == 1 && candidato_2 == 7) || (candidato_1 == 7 && candidato_2 == 1)
        if larg / alt < 0.35 || (exc > 0.965 && sol > 0.50), digito = 1; else, digito = 7; end
    end
    if (candidato_1 == 8 && candidato_2 == 0) || (candidato_1 == 0 && candidato_2 == 8)
        bur = imclearborder(~img); st = regionprops(bur, 'Area');
        if ~isempty(st) && (max([st.Area]) / (alt*larg)) > 0.15, digito = 0; else, digito = 8; end
    end
    if (candidato_1 == 4 && candidato_2 == 6) || (candidato_1 == 6 && candidato_2 == 4)
        if rX < 0.85, digito = 4; else, digito = 6; end
    end
    if furos == 1
        bur_abs = imclearborder(~img); st_abs = regionprops(bur_abs, 'Area', 'Centroid');
        if ~isempty(st_abs)
            [max_a, idx_max] = max([st_abs.Area]);
            cy = st_abs(idx_max).Centroid(2) / alt; 
            if digito == 0 && (max_a / (alt*larg)) < 0.10, digito = 8; end
            if cy > 0.55 && (digito == 9 || digito == 4)
                if digito == 4 && rX < 0.80, digito = 4; else
                    if rY < 0.85, digito = 6; else, digito = 8; end
                end
            end
            if cy < 0.45 && digito == 6
                if rX < 0.90, digito = 9; else, digito = 8; end
            end
        end
    end
    if digito ~= 7 && rY > 1.60 && exc > 0.90 && (larg / alt > 0.40)
        digito = 7;
    end
    if (digito == 6 || digito == 9 || digito == 8 || digito == 0) && rX < 0.68 && rY < 1.2
        digito = 4;
    end
end