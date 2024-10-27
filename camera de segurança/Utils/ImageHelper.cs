using OpenCvSharp;

namespace MotionAndFaceDetectionApp.Utils
{
    public static class ImageHelper
    {
        public static void SalvarImagem(Mat imagem, string caminho)
        {
            Cv2.ImWrite(caminho, imagem);
        }
    }
}
