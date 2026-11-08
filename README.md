ARQUITECTURA DE MICROSERVICIOS E-COMMERCE (.NET 9)

==================================================



Este proyecto es una implementación práctica de una arquitectura de microservicios desarrollada en .NET 9 y C#. El ecosistema está compuesto por tres microservicios independientes (Catálogo, Inventario y Pedidos), cada uno con su propia base de datos en SQL Server para garantizar un bajo acoplamiento.





TECNOLOGÍAS UTILIZADAS

\----------------------

\- Framework: .NET 9.0 (ASP.NET Core Web API)

\- ORM: Entity Framework Core 9.0 (Code-First)

\- Base de Datos: SQL Server

\- Documentación de API: Swashbuckle (Swagger) v10.3.1





ESTRUCTURA DEL PROYECTO

\-----------------------

El sistema se divide en tres APIs autónomas. Las relaciones entre bases de datos distintas se manejan de forma lógica (guardando únicamente el ID de referencia), mientras que las relaciones dentro de la misma base de datos mantienen integridad referencial física (Foreign Keys).



1\. Catalogo.Api (Base de datos: CatalogoDB)

&#x20;  - Tablas: Categoria, Marca, Productos.

&#x20;  - Propósito: Microservicio maestro que administra la información central de los productos a vender.



2\. Inventario.Api (Base de datos: InventarioDB)

&#x20;  - Tablas: Bodega, Stock, MovimientosInv, Existencias.

&#x20;  - Relación Lógica: El IdProducto viaja desde el Catálogo.



3\. Pedidos.Api (Base de datos: PedidosDB)

&#x20;  - Tablas: Clientes, Pedidos, DetallesPedido.

&#x20;  - Relación Lógica: El IdProducto viaja desde el Catálogo hacia el Detalle del Pedido.

&#x20;  - Relación Física: Integridad estricta entre Cliente, Pedido y Detalles dentro de la misma BD.





REQUISITOS PREVIOS

\------------------

\- Visual Studio 2022 (actualizado para soportar .NET 9): https://visualstudio.microsoft.com/es/

\- .NET 9.0 SDK: https://dotnet.microsoft.com/download/dotnet/9.0

\- SQL Server (LocalDB, Express o Developer).





CONFIGURACIÓN Y PUESTA EN MARCHA

\--------------------------------

Para que el proyecto funcione en cualquier equipo, es necesario configurar las cadenas de conexión y generar las bases de datos utilizando las Migraciones de Entity Framework.



Paso 1: Configurar Cadenas de Conexión

\--------------------------------------

Abre el archivo appsettings.json en cada uno de los tres proyectos (Catalogo.Api, Inventario.Api, Pedidos.Api) y modifica el parámetro Server= para que apunte a tu instancia local de SQL Server.



Ejemplo (reemplaza TU\_SERVIDOR por tu instancia local, ej. localhost o SQLEXPRESS):



&#x20;   "ConnectionStrings": {

&#x20;     "CatalogoConnection": "Server=TU\_SERVIDOR;Database=CatalogoDB;Trusted\_Connection=True;TrustServerCertificate=True;"

&#x20;   }



Paso 2: Creación de Bases de Datos y Tablas (Migraciones)

\---------------------------------------------------------

Este proyecto utiliza el enfoque Code-First. No necesitas scripts SQL; Entity Framework creará todo por ti.



Abre Visual Studio, ve a Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes y ejecuta los siguientes comandos en orden, asegurándote de cambiar el "Proyecto predeterminado" en el menú desplegable de la consola para cada paso:



Para el Microservicio 1 (Catalogo.Api):



&#x20;   Add-Migration InicialCatalogo

&#x20;   Update-Database



Para el Microservicio 2 (Inventario.Api):



&#x20;   Add-Migration InicialInventario

&#x20;   Update-Database



Para el Microservicio 3 (Pedidos.Api):



&#x20;   Add-Migration InicialPedidos

&#x20;   Update-Database



Una vez finalizados los tres bloques, tendrás las bases de datos CatalogoDB, InventarioDB y PedidosDB creadas y listas en tu SQL Server.





FLUJO DE PRUEBAS (CÓMO USAR EL SISTEMA)

\---------------------------------------

Debido a que los microservicios dependen de los identificadores lógicos generados por el Catálogo, debes probar los endpoints en este orden específico utilizando Swagger (presionando F5 en cada proyecto):



1\. En Catalogo.Api:

&#x20;  - Crea una Categoría (POST /api/Categorias).

&#x20;  - Crea una Marca (POST /api/Marcas).

&#x20;  - Crea un Producto vinculando los IDs anteriores (POST /api/Productos). Toma nota del IdProducto generado (ej. ID: 1).



2\. En Inventario.Api:

&#x20;  - Crea una Bodega (POST /api/Bodegas).

&#x20;  - Registra Stock (POST /api/Stocks), asignándole el IdBodega recién creado y el IdProducto (ID: 1) que generaste en el Catálogo.



3\. En Pedidos.Api:

&#x20;  - Crea un Cliente (POST /api/Clientes). Toma nota del IdCliente generado.

&#x20;  - Crea la cabecera del Pedido (POST /api/Pedidos) enviando únicamente el total y el IdCliente. Toma nota del IdPedido generado.

&#x20;  - Registra el detalle de la compra (POST /api/DetallesPedido) enviando el IdPedido generado, el IdProducto (ID: 1 del Catálogo), la cantidad y el precio unitario.

