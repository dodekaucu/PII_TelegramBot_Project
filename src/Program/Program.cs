using System;
using System.Threading;
using System.Threading.Tasks;
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
        private static string Token = "2084958009:AAEjaP2ycdqowj9CE3oalnHVacK4x_JwO-8";

        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        public static void Main()
        {
            Bot = new TelegramBotClient(Token);
            
            Rubro testRubro = new Rubro("Tecnologia", "Software", "Programacion");
            Habilitacion testHabilitacion = new Habilitacion("UNIT", "9001");
            Clasificacion testClasifciacion = new Clasificacion("Reciclable", "se puede reciclar");
            Contenedor db = Contenedor.Instancia;
            Busqueda buscador = Busqueda.Instancia;
            Habilitacion msp = new Habilitacion("MSP", "msp");
            Rubro rubro = new Rubro("Forestal", "Leñeria", "Recursos");
            Emprendedor emprendedor = new Emprendedor("Gaston", rubro, "San Ramon", "Ruta 12", "Emprendimiento");
            Empresa maderaslr = new Empresa("Madera SRL", rubro, "San Bautista", "Ruta 6");
            Clasificacion madera = new Clasificacion("Madera", "Roble Oscuro");
            Oferta uno = new Oferta("Madera Para Reciclar", maderaslr, "San", "Bautista", "madera", madera, 1, "Tonelada", 5000, DateTime.Parse("11/11/2021"));
            Oferta dos = new Oferta("Madera Prohibida", maderaslr, "San", "Bautista", "madera", madera, 100, "Kilos", 4000, DateTime.Parse("11/11/2021"));
            uno.AddHabilitacion(msp);
            emprendedor.AddHabilitacion(msp);
            db.AddOferta(uno);
            db.AddOferta(dos);
            

            emprendedor.ID = "1454175798";
            uno.FechaVenta = DateTime.Parse("15/10/2021");
            emprendedor.AddToRegister(uno);
            //Añadir emprendedor (Poner ID de usuario y emprendedor)
            db.AddEmprendedor("1599425094",emprendedor);

            
            firstHandler =
                new HelloHandler(
                new GoodByeHandler(
                new BuscarHandler(
                new BuscarUbiHandler(
                new AdminInvitationHandler(
                new StartHandler(
                new AddAdminHandler(
                new HistorialUsuarioHandler(
                new BuscarClasificHandler(
                new HelpHandler(null)
                )))))))));

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
                    await HandleMessageReceived(update.Message);
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
        private static async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(new TelegramMSGadapter(message), out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, response);
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