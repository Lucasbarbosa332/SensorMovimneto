# SensorMovimneto
Sensor de Movimento usado para câmeras e sensores software independente 

# MotionAndFaceDetectionApp

Este é um projeto de detecção de movimento e reconhecimento facial desenvolvido em C#. Ele utiliza a câmera do notebook para detectar movimento e, com a ajuda de APIs de inteligência artificial, identifica rostos humanos e diferencia animais pequenos de humanos para evitar falsos alarmes. Quando um rosto humano é detectado, um alarme é disparado.

1.Objetivos de Aprendizado
 Com este projeto, você poderá aprender:

* Como configurar e manipular dispositivos de captura de imagem (câmera) em C#.
* Como integrar uma API de inteligência artificial (como a OpenAI API para reconhecimento facial) com um aplicativo em C#.
* Manipulação de arquivos para salvar logs de eventos e configuração.
* Implementação de um sistema básico de notificação com logs de evento.
* Estruturação de um projeto C# em várias classes e pastas para manter a organização e legibilidade.
* Estrutura do Projeto
* graphql
* Copiar código

```
MotionAndFaceDetectionApp/
│
├── MotionAndFaceDetectionApp.sln        # Arquivo de solução do projeto
│
├── Program.cs                           # Arquivo principal que contém a execução do loop de detecção
│
├── Alarme/
│   └── alarme.wav                       # Arquivo de áudio para o alarme
│
├── Models/
│   ├── Config.cs                        # Classe para configurar parâmetros, como a URL e chave da API
│   └── DetectionResult.cs               # Classe modelo para os resultados de detecção da API
│
├── Services/
│   ├── MotionDetector.cs                # Classe responsável pela detecção de movimento
│   ├── FaceRecognizer.cs                # Classe responsável pelo reconhecimento facial (usando ChatGPT API)
│   ├── AnimalDetector.cs                # Classe responsável por identificar animais pequenos
│   └── LoggerService.cs                 # Serviço de log para registrar eventos importantes
│
├── Utils/
│   ├── ApiHelper.cs                     # Função para auxiliar requisições à API
│   └── FileHelper.cs                    # Função auxiliar para manipulação de arquivos de configuração
│
└── Resources/
    ├── Logs/
    │   └── event_log.txt                # Arquivo onde os logs do sistema são salvos
    └── Temp/
        └── frame_temp.jpg               # Imagem temporária capturada para análise


````

# Pré-requisitos
Antes de executar o projeto, você precisará das seguintes dependências:

1. .NET Core SDK - Acesse o site oficial do .NET para baixar e instalar o SDK.

2. API de Reconhecimento Facial - Este projeto integra a OpenAI API (ou uma API equivalente). Configure a chave da API no arquivo config.json.

3. Bibliotecas NuGet - Certifique-se de instalar as seguintes bibliotecas via NuGet:

* Newtonsoft.Json: Para manipulação de JSON.
* System.Drawing.Common: Para manipulação de imagem.
* HttpClient: Para integrar a API de reconhecimento facial (geralmente já incluída no .NET Core).

# Como Baixar e Executar

1. Clone o repositório:

```

git clone https://github.com/seu-usuario/MotionAndFaceDetectionApp.git
cd MotionAndFaceDetectionApp
````
2. Configuração da API:

* Crie um arquivo config.json na pasta Resources.
* Adicione a URL e a chave de API no arquivo config.json:

````

{
  "ApiUrl": "https://api.example.com/recognize",
  "ApiKey": "sua_chave_de_api_aqui",
  "DetectionIntervalMs": 1000
}
````
3. Restaure as dependências:

* No terminal, navegue até a pasta do projeto e execute:

````
dotnet restore
````
4. Execute o projeto:

````
dotnet run
````
# Como Usar
Após iniciar o programa, o sistema monitorará a câmera para detectar movimentos. Quando um movimento é identificado:

* O sistema verificará se é um rosto humano. Caso seja, o alarme será disparado.
* Caso contrário, tentará identificar se o movimento é causado por um animal pequeno, e o alarme não será acionado.
* Todos os eventos serão registrados no arquivo de log em Resources/Logs/event_log.txt.

# Observações

* Este projeto utiliza uma câmera integrada ou conectada ao dispositivo. Certifique-se de conceder permissões de acesso à câmera.
* A API de reconhecimento facial pode ter custos dependendo da plataforma escolhida, então verifique as condições de uso.
* Modifique o intervalo de detecção (DetectionIntervalMs no config.json) conforme necessário para economizar recursos de CPU.

# Contribuição
 Sinta-se à vontade para contribuir com melhorias, novos recursos ou ajustes no código. Para contribuir:

* Crie um fork do repositório.
* Crie uma branch para sua funcionalidade (git checkout -b feature-nome).
* Faça o commit de suas alterações (git commit -m 'Adicionando nova funcionalidade').
* Faça o push para a branch (git push origin feature-nome).
* Abra um Pull Request.
