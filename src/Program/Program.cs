using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;
using Handlers;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un programa que implementa un bot de Telegram.
    /// </summary>
    public static class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        // El token provisto por Telegram al crear el bot.
        //
        // *Importante*:
        // Para probar este ejemplo, crea un bot nuevo y eeemplaza este token por el de tu bot.
        private static string Token = "2106731481:AAEFbR6815bETThGqpF4T3L9yjAbi4zwQDI";

        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Bot = new TelegramBotClient(Token);
            
            Rubro testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            Habilitacion unit = new Habilitacion("UNIT", "9001");
            Clasificacion testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            Contenedor db = Contenedor.Instancia;
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Rubro rubro2 = new Rubro("Tecnologia", "Leñeria", "Recursos");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            db.Invitados.Add("1454175798");
            db.AddRubro(testRubro);
            db.AddRubro(rubro);
            db.AddRubro(rubro2);
            db.AddHabilitacion(msp);
            db.AddHabilitacion(unit);
            db.AddClasificacion(madera);

            //PARA LA PRUEBA
            Empresa empresa = new Empresa("Ichiban Holdings",rubro,"Montevideo","Av.Uruguay","+598 99 777 666");
            db.AddEmpresa("1454175798",empresa);
            Emprendedor emprendedor = new Emprendedor("carlos santana",rubro,"Montevideo","leyes","carpinteria");
            emprendedor.ID = "1566613690";
            db.AddEmprendedor("1566613690",emprendedor);

            
            firstHandler =
                new HelloHandler(
                new InfoUsuarioHandler(
                new CancelHandler(
                new GoodByeHandler(
                new BuscarHandler(
                new BuscarUbiHandler(
                new AdminInvitationHandler(
                new StartHandler(
                new AddAdminHandler(
                new BuscarClasificHandler(
                new HelpHandler(
                new AddPalabraClaveHandler(
                new Registro(
                new AddHabilitacionHandler(
                new PublicarOfertaHandler(
                new MisPublicacionesHandler(
                new AñadirCompradorHandler(
                new HistorialUsuarioHandler(null)
                )))))))))))))))));

            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived((new TelegramMSGadapter(update.Message)));
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(IMessage message)
        {
            Console.WriteLine($"Received a message from {message.ID} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.ID, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}