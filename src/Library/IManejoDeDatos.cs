
namespace Library
{
    public interface IManejoDeDatos
    {
        void GuardarInfo(IManejoDeDatos datos);  // Guarda la información en un archivo
        void DevolverInfo();  // Devuelve la información del archivo
    }
}          