# Prueba-Tecnica-Proveedores

> [!NOTE]
> La Api hace uso de un clouster de mongoAtlas
> Tambien puede hacer uso de mongodb cambiando la cadena de conexcion en el archivo appsettings.json y appsettings.Development.json


## 1. Descargar el repositorio
```
https://github.com/hacadena28/Prueba-Tecnica-Proveedores.git
```
## 2. Navegue hasta el directorio del proyecto
```
cd /ruta-del-repo
```
## 3. Genere la imagen del proyecto usando el archivo Dockerfile
```
docker build -t apiv3 . 
```
## 4. Genere el contenedor de la api usando la imagen
```
docker run -d -p 80:80 --name api apiv3
```
