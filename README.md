                            
PRESENTACION DEL PROYECTO SITIO WEB EN VUE Y VUETIFY CON API EN ASP NET CORE.

El objetivo a alcanzar con este proyecto es el siguiente:

El proyecto consiste en la creaci.ón de un sitio web de sorteos. El frontend estará realizado con el framework vue js y el backend con una api rest en net core, la cual utiliza el lenguaje c#. La base de datos será my sql. El sitio web tendrá un login con registro de usuarios en la base de datos. Para inscribirse en los sorteos abre que ser usuario registrado. También tendrá la opción de que los usuarios de la pagina puedan vender las tarjetas de los sorteos que haya en el sitio web; estas tarjetas tendrán un código QR que le permitirá a los que compren las tarjetas acceder a los sorteos utilizando el móvil. Se mostrará la información de los sorteos vendidos con un alias para cada comprador, se guardará el número de teléfono de cada uno, para contactar con el en caso de salir ganador. El sitio tendrá diferentes pantallas para cada tipo de usuario, ya sea usuario comprador, vendedor, o usuario normal.
Explicación breve de como arrancar el backend:
Los archivos pertenecientes al backend se encuentran en la carpeta WebApi que esta 
Dentro de la carpeta backend.

Para arrancar la api hay que tener instalado visual studio 2022 version comunity, el link de descarga es aquí:
https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&workload=dotnet-dotnetwebcloud&passive=false#dotnet




Para arrancar la api se pincha dos veces en el archivo de solución de visual studio WebApi.sln.

 

Luego dentro del projecto se selecciona la opción http y pincha run:
 

Cuando arranca la api se abre el navegador con la pagina de swagger que nos permite 
Ver los end-points de la api.

 

La base de datos se llama rifa_bd y contiene 3 tablas: cliente, boleto, y premio.

El end point de autenticacion se utiliza para autorizar el ingreso de usuarios a la api con autenticación jwt(json web token). En este sistema de autenticación el cliente envia una solicitud post al endpoint de autenticacion que contiene el usuario, que este caso es el el
Email, y la clave. Las claves guardadas en la base de datos están cifradas con md5, por lo que la api de autenticacion convierte la clave ingresada el md5 para compararla con la clave
Que esta en la base de datos. Una vez autenticado se devuelve un token de respuesta,
Que es valido por 5 minutos.

Los demás endpoints que permiten acceder a las otras tablas están en la carpeta de
Controllers. Se puede observar la directiva [Authorize] en la imagen la cual impide el ingreso si la autorización no esta activada sobre el controlador.

 


Para arrancar la base de datos utilizo un servidor mysql y el sql workbench. El script sql
Para la creación de la tablas se encuentra en la carpeta del proyecto. También incluyo el archivo del modelado de las tablas que se ejecuta con el mysqlworkbench.
Tambien se puede hacer con xampp que ya trae instalado el phpmyadmin. Despues de crear una base de datos llamada rifa_bd ejecutamos el script sql estando dentro de la base de datos y se crean las tablas con lo datos que tengan. El usuario de la base de datos es “root” y el password es  vacio.

Cuando la api arranca se conecta automáticamente con la base de datos.
 
 
Al ejecutar el script se crean las tablas que usa la api.
  


Explicación breve de como arrancar el frontend:

El proyecto de frontend fue realizado el visual studio code, por lo que para verlo bien
Hay que instalarlo y descargarlo desde aquí: https://code.visualstudio.com/

Para ejecutar el proyecto hay que tener instalado node js en el esquipo. Se descarga desde
Aquí : https://nodejs.org/es  la versión LTS estable.

Luego hay que instalar yarn utilizando node, para ello se abre un cmd como administrador
Y se ejecuta npm install --global yarn

 

Luego se abre un power Shell como administrador y se ejecuta Set-ExecutionPolicy -ExecutionPolicy RemoteSigned

 
 
Se selecciona si a todo.

Una vez instalado yarn se abre la carpeta rifa que se encuentra dentro de la carpeta frontend. Para ello se le da botón derecho al mouse sobre la carpeta rifa y se pincha abrir 
con code,
.  


Luego hay que darle a control + ñ para abrir un terminal de visual studio code y escribir
Yarn para que se instalen todos los paquetes de node_nodules.








 
Luego se ejecuta yarn dev verificando que el terminal esta apuntando a la carpeta rifa que es donde esta el proyecto de vue. Al hacer esto se arranca un servidor virtual y nos muesta el puerto del localhost donde arranco .


 





Si la api esta arrancada se entra automáticamente ya que estos valores están sobre escritos
 

Tambien podemos ejecutan npm run dev -o y se abre automáticamente el navegador.
Pero es necesario tener instalado yarn para que se instalen todos los paquetes de vite.


En la carpeta node_mpdules es donde se encuentran todas las librerías que usa el projecto
 
Esta carpeta se crea cuando se ejecuta el comando “yarn”. Al hacer esto se descargan todos los paquetes que están referenciados en el archivo package.json automáticamente y entonces si se puede arrancar el proyecto con “npm run dev -o” o “yarn dev”

 

 
 

En el package.json se encuentran los scripts dev, build y preview. Si ejecutamos npm run build se crean los archivos que se utilizan cuando vamos a subir nuestro sitio en un servidor en la carpeta dist.

 
 
 

Si ejecutamos npm run preview arranca el sitio listo para producccion.

 

 

Luego de arrancar la api en visual studio se accede automáticamente
 

Después de recargar el navegador
 
