# Prueba-Tecnica-Proveedores

## 1. Descargar el repositorio
```
https://github.com/hacadena28/Prueba-Tecnica-Proveedores.git
```
## 2. Descargar imagen de mongo en docker
```
docker pull mongo
```
## 3. Crear una red interna para conectar la el contenedor de la api con el contenedor de la base de datos
```
docker network create api-mongo
```
## 4. Inicia el contenedor de mongo
```
docker run -d --name mongoApi -p 27017:27017 --network=api-mongo
```
## 5. Navegue hasta el directorio del proyecto
```
cd /ruta-del-repo
```
## 6. Genere la imagen del proyecto usando el archivo Dockerfile
```
docker build -t image-api-proveedores .
```
## 7. Genere el contenedor de la api usando la imagen
```
docker run -d --name apiProveedores -p 80:80 --network=api-mongo image-api-proveedores
```
