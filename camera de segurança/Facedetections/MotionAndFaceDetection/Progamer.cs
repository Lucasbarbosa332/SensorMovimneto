using System;
using System.Threading.Tasks;
using MotionAndFaceDetectionApp.Services;
using MotionAndFaceDetectionApp.Utils;

namespace MotionAndFaceDetectionApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LoggerService logger = new LoggerService();
            MotionDetector motionDetector = new MotionDetector();
            FaceRecognizer faceRecognizer = new FaceRecognizer();
            AnimalDetector animalDetector = new AnimalDetector();
            Config config = FileHelper.LoadConfig<Config>("config.json");

            logger.RegistrarLog("Iniciando o sistema de detecção de movimento e reconhecimento facial");

            while (true)
            {
                bool movimentoDetectado = motionDetector.DetectarMovimento();

                if (movimentoDetectado)
                {
                    logger.RegistrarLog("Movimento detectado");

                    // Captura a imagem e envia para o reconhecimento facial
                    bool rostoReconhecido = await faceRecognizer.ReconhecerRostoAsync();
                    if (rostoReconhecido)
                    {
                        logger.RegistrarLog("Rosto humano reconhecido");
                        Alerta();
                    }
                    else
                    {
                        bool animalIdentificado = animalDetector.DetectarAnimalPequeno();
                        if (animalIdentificado)
                        {
                            logger.RegistrarLog("Animal pequeno identificado - alarme não disparado");
                        }
                        else
                        {
                            logger.RegistrarLog("Movimento detectado, mas nenhum rosto humano ou animal pequeno identificado");
                            Alerta();
                        }
                    }
                }

                // Adiciona uma pausa para reduzir o uso de CPU
                await Task.Delay(config.DetectionIntervalMs);
            }
        }

        static void Alerta()
        {
            Console.WriteLine("Alarme disparado! Ação necessária.");
            // Aqui poderia tocar um som ou ativar uma notificação em tempo real
        }

        // Função adicional para verificar a atividade do sensor
        static void VerificarAtividadeSensor()
        {
            // Esta função poderia ser executada em um intervalo para garantir que o sensor esteja ativo
            Console.WriteLine("Verificando atividade do sensor...");
        }

        // Função para exportar logs detalhados
        static void ExportarLogs()
        {
            // Esta função pode ser chamada para exportar logs completos para análise ou auditoria
            LoggerService logger = new LoggerService();
            string logs = logger.ExportarTodosLogs();  // Exemplo de função a adicionar no LoggerService
            Console.WriteLine("Logs exportados com sucesso!");
        }
    }
}
