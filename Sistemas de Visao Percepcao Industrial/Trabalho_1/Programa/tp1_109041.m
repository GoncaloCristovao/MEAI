function n_mec = tp1_109041()
% Analisar uma serie de imagens e deteta, em cada uma delas, os seguintes parametros:
% - Número de peças de dominó.
% - Número de faces de dados de jogo.
% - Número de cartas de jogo.
% - Número de peças de dominó numa dada orientação.
% - Número de faces de dados numa dada orientação.
% - Número de peças de dominó com igual número de pintas em cada lado (duplas).
% - Números totais acumulados de pintas das peças de dominó e dos dados.
% - Número de cartas de jogo de certos naipes.
% - String com os dígitos do número de pintas de todas as cartas ordenados de forma crescente.
% - No final, retorna o nº mecanográfico 109041 e gera um ficheir .txt.
close all; clc;
    
    n_mec = 109041;
    
    % Adicionar path para as imagens 
    addpath('../');      
    % Ler todas as imagens 
    lista_Img = dir('../svpi2026_TP1_img_*.png');
    
    % Criar o ficheiro de texto para escrita
    nome_ficheiro = sprintf('tp1_%d.txt', n_mec);
    fid = fopen(nome_ficheiro, 'w');
    
    for n = 1:length(lista_Img)
        nome = lista_Img(n).name;
        num_serie = str2double(nome(18:20));
        num_img = str2double(nome(22:23));
        
        % Ler a imagem
        caminho_completo = fullfile(lista_Img(n).folder, lista_Img(n).name);
        Img = im2double(imread(caminho_completo));
        
        % ----------------------------------------------------
        % Deteção dos Caixilhos
        % Binarizar a imagem para isolar os caixilhos pretos 
        caixilhos = Img == 0; 
        % Preencher os caixilhos 
        caixilhos = imfill(caixilhos, 'holes');
        % Limpeza
        elemento_estruturante = strel('square', 3);
        caixilhos = imopen(caixilhos, elemento_estruturante);
        % Limpar restos de ruído perdidos no fundo 
        caixilhos = bwareaopen(caixilhos, 2000);
        % Obter as caixas delimitadoras
        regioes_detetadas = regionprops(caixilhos, 'BoundingBox');
        
        % Inicializar contadores 
        contador_objetos = 0;
        ListaObjetos = {}; 
        margem = 0; 
        tDom = {};
        tCard = {};
        tDice = {};
        
        for i = 1:length(regioes_detetadas)
            caixa_delimitadora = regioes_detetadas(i).BoundingBox;
            
            largura = round(caixa_delimitadora(3));
            altura  = round(caixa_delimitadora(4));
            
            % Filtrar por tamanho
            if largura > 30 && altura > 30
                contador_objetos = contador_objetos + 1;
                
                % Coordenadas da caixa
                x_exato = round(caixa_delimitadora(1));
                y_exato = round(caixa_delimitadora(2));
                
                % Garantir que não saí fora da imagem (max/min)
                x_inicial = max(1, x_exato - margem);
                y_inicial = max(1, y_exato - margem);
                
                % Subtrair 1 e limitar o tamanho máximo aos limites da imagem
                x_final = min(x_inicial + largura - 1 + margem, size(Img, 2));
                y_final = min(y_inicial + altura - 1 + margem, size(Img, 1));
                
                % Recortar o objeto
                imagem_recortada = Img(y_inicial:y_final, x_inicial:x_final);
                ListaObjetos{contador_objetos} = imagem_recortada;
            end
        end
        
        % ------------------------------------------------------
        % Classificação dos objetos
        for k = 1:contador_objetos
            peca_atual = ListaObjetos{k};
            [altura, largura, ~] = size(peca_atual);
            
            % Margem de erro de 25 píxeis devido aos recortes feitos na Caixa Delimitadora
            tolerancia = 25; 
            
            % Largura é igual a Altura, Dados
            if abs(largura - altura) <= tolerancia
                tDice{end+1} = peca_atual;
                
            % Um lado é o dobro do outro, Dominos
            elseif abs(largura - (altura * 2)) <= tolerancia || abs(altura - (largura * 2)) <= tolerancia
                tDom{end+1} = peca_atual;
                
            % O resto são Cartas
            else
                tCard{end+1} = peca_atual;
            end
        end
        
        dominos_total = length(tDom);
        dados_total = length(tDice);
        cartas_total = length(tCard); 
        
        % -----------------------------------------------------
        % Identificar Propriedades dos Dominos 
        RDO = 0;
        tDuplas = 0;
        PntDom = 0;
        
        for g = 1:length(tDom)
            A = tDom{g};
            [altura, largura] = size(A);
            
            if largura > altura
                RDO = RDO + 1;
            end
            if altura > largura
                A = A'; 
            end
            
            % Corte de 4 píxeis de cada lado para remover apenas a linha preta do caixilho.
            corte_inicio = 4; 
            corte_fim = 4;       
            A_sem_borda = A(corte_inicio : end-corte_fim, corte_inicio : end-corte_fim);
            
            % Remoção de ruido e ajuste de contraste
            A_suave = medfilt2(A_sem_borda, [3 3]);
            A_suave = imadjust(A_suave); 
            
            % Deteção da linha central

            A_arestas = edge(A_suave, 'canny'); % Detetar os contornos
            
            meio_linha = round(size(A_arestas, 2) / 2);
            % Margem baseada no tamanho da peça 
            margem_linha = max(1, round(size(A_arestas, 2) * 0.05)); 
            
            faixa_central = A_arestas(:, max(1, meio_linha - margem_linha) : min(size(A_arestas, 2), meio_linha + margem_linha));
            altura_peca = size(A_arestas, 1);
            
            tem_linha = sum(faixa_central(:)) > (altura_peca * 0.15); 
            
            if ~tem_linha
                % Não tem linha central, é um objeto desconhecido
                if dominos_total > 0
                    dominos_total = dominos_total - 1;
                end
                
                % Caso tenha sido contado como horizontal (RDO)
                if largura > altura && RDO > 0
                    RDO = RDO - 1;
                end
                
                continue; % Salta a contagem de pintas se não tiver linha
            end
            
            % Continua com a binarização normal
            limiar = graythresh(A_suave);
            A_bin = imbinarize(A_suave, limiar);
            
            if sum(A_bin(:)) > numel(A_bin)/2
                A_bin = ~A_bin; 
            end
            
            A_bin = imopen(A_bin, strel('square', 2));
            A_bin = bwareaopen(A_bin, 15); 
            
            % Dividir o dominó exatamente a meio
            meio = round(size(A_bin, 2) / 2);
            DomEsq = A_bin(:, 1:meio); 
            DomDir = A_bin(:, meio+1:end);
            
            % Apagar píxeis de cada lado para não cortar as pintas
            DomEsq(:, end-2:end) = 0; 
            DomDir(:, 1:3) = 0;
            
            % Metade Esquerda
            stats_esq = regionprops(DomEsq, 'Area');
            pintas_esq = 0;
            if ~isempty(stats_esq)
                areas_esq = [stats_esq.Area];
                if mean(areas_esq) >= 20 % Área mínima
                    area_max_esq = max(areas_esq);
                    DomEsq = bwareaopen(DomEsq, round(area_max_esq / 2)); 
                    [~, pintas_esq] = bwlabel(DomEsq, 4); 
                end
            end
            
            % Metade Direita
            stats_dir = regionprops(DomDir, 'Area');
            pintas_dir = 0;
            if ~isempty(stats_dir)
                areas_dir = [stats_dir.Area];
                if mean(areas_dir) >= 20
                    area_max_dir = max(areas_dir);
                    DomDir = bwareaopen(DomDir, round(area_max_dir / 2)); 
                    [~, pintas_dir] = bwlabel(DomDir, 4);
                end
            end
            
            % Soma final com limite de segurança
            if pintas_esq <= 6 && pintas_dir <= 6
                PntDom = PntDom + pintas_esq + pintas_dir;
                if pintas_esq == pintas_dir
                    tDuplas = tDuplas + 1;
                end
            else
                % A peça ultrapassou o limite de 6 marcas e é um objeto sem significado
                if dominos_total > 0
                    dominos_total = dominos_total - 1;
                end
                if largura > altura && RDO > 0
                    RDO = RDO - 1;
                end
            end
        end
        
        % ---------------------------------------------
        % Identificar Propriedades dos Dados 
        RFO = 0;
        PntDad = 0;
        
        for j = 1:length(tDice)
            % Detetar Orientação
            B = tDice{j};
            mascara = B < 0.15;
            mascara = bwareaopen(mascara, 25);
            mascara = imfill(mascara, 'holes');
            
            if (sum(mascara(:)) / numel(mascara)) < 0.70 
                orientacao = '45º';
                % Rodar e cortar
                B_rodado = imrotate(B, 45, 'bilinear', 'crop');
                D = size(B, 1);
                L = floor(D / sqrt(2));
                centro = floor(D / 2);
                B_limpo = B_rodado(centro - floor(L/2) + 4 : centro + floor(L/2) - 3, ...
                                   centro - floor(L/2) + 4 : centro + floor(L/2) - 3);
            else
                orientacao = '0º'; 
                RFO = RFO + 1; 
                B_limpo = B(3:end-2, 3:end-2);
            end
            
            % Remoção de ruido e binarização
            B_suave = medfilt2(B_limpo, [3 3]);
            B_suave = imadjust(B_suave); 
            T = graythresh(B_suave);
            B_bin = imbinarize(B_suave, T);
            
            totWhite = nnz(B_bin);
            if(totWhite > numel(B_bin)/2)
                B_bin = ~B_bin;
            end
            
            % Contagem 
            B_bin = bwareaopen(B_bin, 25);
            stats = regionprops(B_bin, 'Area');
            numero_pintas = 0;
            
            if ~isempty(stats)
                areas = [stats.Area];
                area_mean = mean(areas);
                
                if area_mean >= 40
                    area_max = max(areas);
                    B_bin = bwareaopen(B_bin, round(area_max/2));
                    
                    stats_finais = regionprops(B_bin, 'Circularity');
                    for p = 1:length(stats_finais)
                        if stats_finais(p).Circularity > 0.45 
                            numero_pintas = numero_pintas + 1;
                        end
                    end
                else
                    numero_pintas = 0; 
                end
            else
                numero_pintas = 0; 
            end
            
            % Validação e remoção de lixo
            if numero_pintas >= 1 && numero_pintas <= 6
                PntDad = PntDad + numero_pintas;
            else
                if strcmp(orientacao, '0º') && RFO > 0, RFO = RFO - 1; 
                end
                if dados_total > 0, dados_total = dados_total - 1; 
                end
            end
        end
        
        % ---------------------------------------------
        % Identificar Propriedades das Cartas
        CopOuros = 0;
        EspPaus = 0;
        Ouros = 0;
        NumPintas = [];
        
        for k = 1:length(tCard)
            C = tCard{k};
            
            % Remoção do caixilho
            C_limpo = C(3:end-2, 3:end-2);
            
            % Limpeza de ruído
            C_suave = medfilt2(C_limpo, [3 3]);
            
            % Binarização 
            T = graythresh(C_suave);
            C_bin = imbinarize(C_suave, T);
            
            if nnz(C_bin) > numel(C_bin)/2
                C_bin = ~C_bin; 
            end
            
            C_bin = bwareaopen(C_bin, 25);
            stats = regionprops(C_bin, 'Area');
            
            if ~isempty(stats)
                areas = [stats.Area];
                area_mean = mean(areas);
                
                if area_mean >= 50  
                    area_max = max(areas);
                    
                    % Isolar as pintas centrais removendo os cantos pequenos
                    C_pintas = bwareaopen(C_bin, round(area_max / 2));
  
                    % Apagar manchas que toquem na borda do recorte
                    C_pintas = imclearborder(C_pintas);
                    
                    % Contagem com bwlabel
                    [~, num_objetos] = bwlabel(C_pintas, 4);
                    
                    % Validação final do número de objetos
                    if num_objetos >= 1 && num_objetos <= 9
                        NumPintas(end+1) = num_objetos;
                        
                        % Lógica de Intensidade (Tonalidade)
                        intensidade_media = mean(C_limpo(C_pintas));
                        stats_finais = regionprops(C_pintas, 'Eccentricity');
                        eccen_media = mean([stats_finais.Eccentricity]);
                        
                        if intensidade_media < 0.35
                            EspPaus = EspPaus + 1;
                        else
                            CopOuros = CopOuros + 1;
                            if eccen_media >= 0.43
                                Ouros = Ouros + 1;
                            end
                        end
                    else
                        % Número de pintas inválido
                        if cartas_total > 0, cartas_total = cartas_total - 1;
                        end
                    end
                else
                    % Confirmacao na área média, ruido
                    if cartas_total > 0, cartas_total = cartas_total - 1; 
                    end
                end
            else
                % Imagem vazia
                if cartas_total > 0, cartas_total = cartas_total - 1; 
                end
            end
        end
        
        % Construção da String ordenada
        NumPintas = sort(NumPintas);
        StringPT = '';
        for l = 1:length(NumPintas)
            StringPT = strcat(StringPT, num2str(NumPintas(l)));
        end
    
        % ---------------------------------------------
        % Escrita no ficheiro .txt
        fprintf(fid, '%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%d,%s\n', ...
            n_mec, num_serie, num_img, dominos_total, dados_total, cartas_total, ...
            RDO, RFO, tDuplas, PntDom, PntDad, CopOuros, EspPaus, Ouros, StringPT);
            
    end 
    
    fclose(fid);
end