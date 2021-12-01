<h1 align="center">
  Telegram Bot powered by DoDeka
</h1>

<blockquote>
  <p align="center">
Este proyecto consta de desarrollar un chatbot el cual tratara de conectar empresas y organizaciones con emprendedores.
    (El nombre del bot es @dodeKa_bot)
  </p>
</blockquote>

<h2>Resumen del proeyecto: </h2>

  <p>
  La idea principal del proyecto es generar un bot siguiendo las historias de usuario pautadas a continuacion. En este mismo se busca conectar empreas que ofrecen residuos asi como materiales reciclables, con emprendedores que puedan aprovechar dicho desecho. Todo esto para cumplir una economia circular.
  </p>
<h4>HISTORIAS DE USUARIO: (los requerimientos que tenia que cumplir el bot)</h4>
  <p>
•	Como administrador, quiero poder invitar empresas a la plataforma, para que de esa forma puedan realizar ofertas de materiales reciclables o residuos.<br>
•	Como empresa, quiero aceptar una invitación a unirme en la plataforma y registrar mi nombre, ubicación y rubro, para que de esa forma pueda comenzar a publicar ofertas.<br>
•	Como empresa, quiero publicar una oferta de materiales reciclables o residuos, para que de esa forma los emprendedores que lo necesiten puedan reutilizarlos.<br>
•	Como empresa, quiero clasificar los materiales o residuos, indicar su cantidad y unidad, el valor (en $ o U$S) de los mismos y el lugar donde se ubican, para que de esa forma los emprendedores tengan información de materiales o residuos disponibles.<br>
•	Como empresa, quiero indicar las habilitaciones que requiere un emprendedor, para que de esa forma pueda recibir o retirar los materiales o residuos.<br>
•	Como empresa, quiero indicar un conjunto de palabras claves asociadas a la publicación de los materiales, para que de esa forma sea más fácil de encontrarlos en las búsquedas que hacen los emprendedores.<br>
•	Como emprendedor, quiero registrarme en la plataforma indicando nombre, ubicación, rubro, habilitaciones y especializaciones, para que de esa forma pueda ver las ofertas de materiales o residuos.<br>
•	Como emprendedor, quiero poder buscar materiales ofrecidos por empresas mediante palabras clave, categorías, o por zona, para de esa forma obtener insumos para mi emprendimiento.<br>
•	Como emprendedor, quiero saber qué materiales se generan constantemente, para de esa forma planificar que insumos tengo disponibles. <br>
•	Como emprendedor, quiero saber cuándo un material o residuo se genera puntualmente, para de esa forma determinar oportunidades de desarrollar nuevos productos. <br>
•	Como empresa, quiero saber todos los materiales o residuos entregados en un período de tiempo, para de esa forma tener un seguimiento de su reutilización.<br>
•	Como emprendedor, quiero saber cuántos materiales o residuos consumí en un período de tiempo, para de esa forma tener un control de mis insumos. <br>
  </p>

<h3 align="center">Diagrama de interaccion de las diferentes rutas del BOT</h3>
<img src = "docs\RUTASdelBOT.png">

<h2 align="center">
Bitacora Proyecto:
</h2>

  Para la primer entrega lo mas desafiante fue el identificar correctamente las clases necesarias para el proyecto, pero sobretodo hacerlo respetando los principios anteriormente vistos en clase. El primer planteo incluyo solamente 5 clases diferentes, a medida que se indagó en el funcionamiento del programa, fue evidente que ibas a ser necesarias muchas mas clases complementarias para respetar el SRP.
  
  Fue necesario informarse sobre el funcionamiento(a nivel basico) del chatbot de Telegram para asi diseñar nuestro problema y que sean compatibles.
  Tambien aprender mas en profundidad el formato de los diagramas de clases(que si bien fueron mencionados en clase, fue de manera breve y muy por encima.
  
  Al avanzar con el proyecto fue evidente que la implementacion de los patrones GRASP y los principios SOLID no solo facilitaban el entendimiento del codigo para otros integrantes al hacer el Pull Request sino que tambien, inadvertidamente, nos daban la posibilidad de reutilizar, modificar de manera simple o extender ciertas clases o partes de codigo de manera muy sencilla. No solo el codigo era mucho mas flexible para que alguien pudiera agregar sus partes por separado sino que era evidente que en los lugares que tuvimos mas en cuenta estos patrones y/o principios uno podia trabajar con mucha mas soltura y sin tener que comprobar en distintos lugares del código si eso generaria alguna incompatibilidad no prevista, al fin y al cabo esto nos ahorro mucho tiempo y logró un correcto funcionamiento del Programa.
 
CONTEXTUALIZACIÓN
  Para la realización de la entrega 1 de este proyecto comenzamos indagando acerca de como realizar las tarjetas CRC y el diagrama UML. En el proceso nos encontramos con la herramienta CRC Maker, en la página "https://echeung.me/crcmaker/" donde, a través de tutoriales en YouTube, logramos realizarlas de forma práctica y didáctica. Al mismo tiempo, para hacer el diagrama UML recurrimos a más tutoriales de YouTube y foros de Reddit, donde nos encontramos con la herramienta Draw.io como la más recomendada. fue así que terminamos utilizandolo desde su página "https://app.diagrams.net/" y hasta utilizamos su versión de escritorio descargada de "https://www.diagrams.net/" (recomendamos la segunda por su rapidez de acceso y desempeño de la herramienta).
  
  Comenzamos indagación sobre la aplicación Telegram, ya que varios del equipo no se habían interiorizado o siquiera la habían usado alguna vez. Para ello cada uno se descargó la app y al mismo tiempo comenzò a utilizarla. Se investigó sobre operaciones realizadas por chatbots y sus utilidades en foros y videos varios.
  
  Asi como fue necesario aprender del funcionamiento de la aplicacion Telegram, fue evidente que era necesario el familiarizarse con el funcionamiento de los ChatBots e indagar mas a fondo en el de Telegram en especifico. Tambien tuvimos problemas con respecto al Doxygen "https://www.doxygen.nl/index.html", mas bien en su instalacion, ya que eran necesarias las intalaciones de diferentes extensiones para lograr que funcionara, y desde el comienzo del curso no habiamos tocado el tema de las extensiones por lo que fue necesario ver su funcionamiento para asi poder utilizar esta herramienta.

<h4>PROBLEMAS:</h4><br>Al utilizar la api de persistencia nos encontramos con el problema de que nuestras clases Oferta, OfertaPersistente, Empresa y Emprendedor no eran compatibles con la misma.
Antes utilizabamos el patrón de herencia para Oferta y OfertaRecurrente, para eso teniamos una clase abstracta OfertaBase y esta era la que se guardaba en nuestra "base de datos" Contenedor. Con Empresa y Emprendedor era lo mismo pero con la clase abstracta Usuario, ya que la api de persistencia no funciona cpn clases abstractas tuvimos que hacer dos clases muy similares para oferta y ofertapersistente, y para empresa y emprendedor.

<h3>Diagramas UML</h3>
<img src = "docs\DiagramasUMLfinal.png">

<h3>Tarjetas CRC</h3>

<a herf = "https://echeung.me/crcmaker/?share=W3sibmFtZSI6IkFkbWluIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQ29ub2NlciBOb21icmUgZGVsIEFkbWluIiwiRW52aWFyIG1lbnNhamUgYSBsYSBFbXByZXNhIl0sImNvbGxhYm9yYXRvcnMiOlsiIl19LHsibmFtZSI6IkVtcHJlbmRlZG9yIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQ29ub2NlciBub21icmUiLCJDb25vY2VyIHViaWNhY2nzbiIsIkNvbm9jZXIgcnVicm8iLCJDb25vY2VyIGhhYmlsaXRhY2lvbmVzIiwiQ29ub2NlciBlc3BlY2lhbGl6YWNpb25lcyIsIlRlbmVyIHVuIHJlZ2lzdHJvIiwiQWdyZWdhciBIYWJpbGl0YWNpb25lcyJdLCJjb2xsYWJvcmF0b3JzIjpbIlVzdWFyaW8iLCJJSnNvblNlcmlhbGl6ZSJdfSx7Im5hbWUiOiJFbXByZXNhIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQWNlcHRhciBJbnZpdGFjaW9uIiwiQ29ub2NlciBOb21icmUiLCJDb25vY2VyIFViaWNhY2lvbiIsIkNvbm9jZXIgUnVicm8iLCJDb25vY2VyIGxhcyBvZmVydGFzIiwiVGVuZXIgdW4gcmVnaXN0cm8iXSwiY29sbGFib3JhdG9ycyI6WyJVc3VhcmlvIiwiSUpzb25TZXJpYWxpemUiLCJVYmljYWNp824iXX0seyJuYW1lIjoiVXN1YXJpbyIsInN1cGVyY2xhc3NlcyI6IiIsInN1YmNsYXNzZXMiOiIiLCJ0eXBlIjoyLCJyZXNwb25zaWJpbGl0aWVzIjpbIkNvbm9jZXIgTm9tYnJlIiwiQ29ub2NlciBSdWJybyIsIkFncmVnYXIgT2ZlcnRhIGFsIFJlZ2lzdHJvIl0sImNvbGxhYm9yYXRvcnMiOlsiVWJpY2FjaW9uIl19LHsibmFtZSI6IkJ1c3F1ZWRhIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQnVzY2FyIHVuYSBPZmVydGEgZW4gZWwgcmVnaXN0cm8gZGUgT2ZlcnRhcyJdLCJjb2xsYWJvcmF0b3JzIjpbIkNvbnRlbmVkb3IiXX0seyJuYW1lIjoiTWF0ZXJpYWwiLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MSwicmVzcG9uc2liaWxpdGllcyI6WyJDb25vY2VyIGxhIENsYXNpZmljYWNp824gIiwiQ29ub2NlciBsYSBjYW50aWRhZCIsIkNvbm9jZXIgbGEgdW5pZGFkIGRlIG1lZGlkYSIsIkNvbm9jZXIgZWwgcHJlY2lvIGRlIGxhIHVuaWRhZCJdLCJjb2xsYWJvcmF0b3JzIjpbIkNsYXNpZmljYWNp824iXX0seyJuYW1lIjoiT2ZlcnRhIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQ29ub2NlciBsYSBmZWNoYSBkZSBjcmVhY2lvbiBkZSBsYSBPZmVydGEiLCJDb25vY2VyIE9mZXJ0YUJhc2UiXSwiY29sbGFib3JhdG9ycyI6WyJPZmVydGFCYXNlIl19LHsibmFtZSI6Ik9mZXJ0YUJhc2UiLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MiwicmVzcG9uc2liaWxpdGllcyI6WyJDb25vY2VyIG5vbWJyZSBkZSBsYSBPZmVydGEiLCJDb25vY2VyIEZlY2hhIGRlIGxhIE9mZXJ0YSIsIkNvbm9jZXIgZWwgTWF0ZXJpYWwgZGUgbGEgT2ZlcnRhIiwiQ29ub2NlciBsYSBFbXByZXNhIG9mZXJ0YW50ZSIsIkNvbm9jZXIgbGEgdWJpY2FjaW9uIGRlIGxhIE9mZXJ0YSAoY2l1ZGFkLCBjYWxsZSkiLCJDb25vY2VyIGxhcyBwYWxhYnJhcyBjbGF2ZXMgZGUgbGEgT2ZlcnRhIiwiQ29ub2NlciBsYXMgSGFiaWxpdGFjaW9uZXMgZGUgbGEgT2ZlcnRhIl0sImNvbGxhYm9yYXRvcnMiOlsiTWF0ZXJpYWwiLCJFbXByZXNhIiwiSGFiaWxpdGFjaW9uZXMiXX0seyJuYW1lIjoiT2ZlcnRhUmVjdXJyZW50ZSIsInN1cGVyY2xhc3NlcyI6IiIsInN1YmNsYXNzZXMiOiIiLCJ0eXBlIjoxLCJyZXNwb25zaWJpbGl0aWVzIjpbIkNvbm9jZXIgT2ZlcnRhQmFzZSIsIkNvbm9jZXIgbGEgcmVjdXJyZW5jaWEgbWVuc3VhbCJdLCJjb2xsYWJvcmF0b3JzIjpbIk9mZXJ0YUJhc2UiXX0seyJuYW1lIjoiVWJpY2FjaW9uIiwic3VwZXJjbGFzc2VzIjoiIiwic3ViY2xhc3NlcyI6IiIsInR5cGUiOjEsInJlc3BvbnNpYmlsaXRpZXMiOlsiQ29ub2NlciBjaXVkYWQiLCJDb25vY2VyIGNhbGxlIl0sImNvbGxhYm9yYXRvcnMiOlsiIl19LHsibmFtZSI6IkNsYXNpZmljYWNp824iLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MSwicmVzcG9uc2liaWxpdGllcyI6WyJDb25vY2VyIG5vbWJyZSBkZSBsYSBDbGFzaWZpY2FjafNuIiwiQ29ub2NlciBkZXNjcmlwY2nzbiBkZSBsYSBDbGFzaWZpY2FjafNuIl0sImNvbGxhYm9yYXRvcnMiOlsiIl19LHsibmFtZSI6IkRhdG9zVGVtcG9yYWxlcyIsInN1cGVyY2xhc3NlcyI6IiIsInN1YmNsYXNzZXMiOiIiLCJ0eXBlIjoxLCJyZXNwb25zaWJpbGl0aWVzIjpbIkFncmVnYXJEYXRvcyJdLCJjb2xsYWJvcmF0b3JzIjpbIiJdfSx7Im5hbWUiOiJIYWJpbGl0YWNp824iLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MSwicmVzcG9uc2liaWxpdGllcyI6WyJDb25vY2VyIG5vbWJyZSBkZSBsYSBIYWJpbGl0YWNp824iXSwiY29sbGFib3JhdG9ycyI6WyJDb25vY2VyIGRlc2NyaXBjafNuIGRlIGxhIEhhYmlsaXRhY2nzbiJdfSx7Im5hbWUiOiJJSnNvblNlcmlhbGl6ZXIiLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MywicmVzcG9uc2liaWxpdGllcyI6WyJDb252ZXJ0aXIgYSBKc29uIiwiQ2FyZ2FyIGRlIEpzb24iXSwiY29sbGFib3JhdG9ycyI6WyIiXX0seyJuYW1lIjoiUmVmZXJlbmNlcyIsInN1cGVyY2xhc3NlcyI6IiIsInN1YmNsYXNzZXMiOiIiLCJ0eXBlIjoxLCJyZXNwb25zaWJpbGl0aWVzIjpbIkFzaXN0aXIgZW4gbGEgU2VyaWFsaXphY2nzbi9EZXNlcmlhbGl6YWNp824iXSwiY29sbGFib3JhdG9ycyI6WyIiXX0seyJuYW1lIjoiUnVicm8iLCJzdXBlcmNsYXNzZXMiOiIiLCJzdWJjbGFzc2VzIjoiIiwidHlwZSI6MSwicmVzcG9uc2liaWxpdGllcyI6WyJDb25vY2VyIG5vbWJyZSBkZWwgUnVicm8iLCJDb25vY2VyIGFyZWEgZGVsIFJ1YnJvIiwiQ29ub2NlciBkZXNjcmlwY2lvbiBkZWwgUnVicm8iXSwiY29sbGFib3JhdG9ycyI6WyIiXX0seyJuYW1lIjoiVXNlclN0YXR1cyIsInN1cGVyY2xhc3NlcyI6IiIsInN1YmNsYXNzZXMiOiIiLCJ0eXBlIjoxLCJyZXNwb25zaWJpbGl0aWVzIjpbIkNvbm9jZXIgZWwgZXN0YWRvIGRlbCBjaGF0IiwiQWdyZWdhciBrZXl1c2VyIiwiTW9kaWZpY2FyIGVsIHVzZXJzdGF0dXMiXSwiY29sbGFib3JhdG9ycyI6WyIiXX1d">TARJETA CRC (CRC MAKER) </a>
