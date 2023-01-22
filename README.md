# HolidayConsole
App de consola para reservar viajes

Para poder descargar y ejecutar la aplicación en tu ordenador, deberás ejecutar los siguientes comandos:
- docker pull adapiedrafita/holidayconsoleapp:1.3
- docker run -it -p 6216:1000 adapiedrafita/holidayconsoleapp:1.3

He realizado una aplicación de consola de .net para usuarios que quieren reservar viajes.
El modelo de datos tiene 3 clases: usuarios, viajes y reservas. Los usuarios y los viajes están relacionados con las reservas (una reserva la realiza un usuario y reserva un viaje).

Las funcionalidades que he realizado son:
- Menú principal y secundarios para navegar. La consola ofrecerá un menú al usuario con opciones a realizar y dentro de esas opciones, habrá más opciones de interacción.
- Gestión de alta y selección. El usuario podrá dar de alta usuarios y reservas. Se podrán seleccionar viajes para reservar.
- Zona privada de información: el usuario tendrá que loguearse para acceder a esta zona. Así podrá reservar viajes, consultar sus reservas y consultar su información personal.
- Zona pública de información: todos los usuarios podrán ver y buscar viajes, además de loguearse y registrar un nuevo usuario. A esta zona tendrán acceso sin necesidad de registro.
- Modelo de datos con 3 clases relacionas y cada una 6 atributos de distintos tipos.
- Funcionalidad de búsqueda: los usuarios pueden buscar viajes por el campo destino.
- Aplicación contenerizada. HHe configurado el puerto de docker para ser el de mi usuario de san valero: 	6216. También he creado un volumen al que le he asociado un contenedor con la última imagen de mi aplicativo en docker, con el puerto previamente comentado.
- He creado un repositorio en DockerHub para alojar mis contenedores y que otros usuarios tengan acceso a ellos. Indico arriba de este archivo cómo descargar la aplicación y ejecutarla.
El comando que he utilizado para crear el volumen y asociar un nuevo contenedor es docker run -it -p 6216:1000 -v holidayconsoleapp:/var/lob/mysql holidayconsole:1.3
- He utilizado git  la metodología gitflow. Adjunto aquí enlace a mi repositorio: https://github.com/adiixxx96/HolidayConsole
- Escribir y almacenar datos en ficheros Json. Todos los datos de mi aplicación (usuarios, viajes y reservas) se cargan desde un json al ejecutar la aplicación. Al añadir o modificar registros (dar de alta usuarios, reservar viajes y actualizar las plazas de un viaje), los datos se mandan al json que queda actualizado.
- He usado Spectre.Console para mejorar la experiencia de usuario en la consola.
