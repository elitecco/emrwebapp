You need to publish inside 'publish' folder before you can create an image from the Dockerfile.

You will need to map port 5000 when you create the container.

----
Build the image:
$ docker build -t emrapp01 .

Run image in a new container:
$ docker run -p 5000:5000 --name myapp emrapp01
