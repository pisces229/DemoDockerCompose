# DemoDockerCompose

## [Docker Compose](https://docs.docker.com/compose/)

[Ubuntu](https://hub.docker.com/_/ubuntu)

`docker pull ubuntu`

`docker run --name demo-ubuntu -t -i -d -v demo-volume:/data ubuntu bash`

[Nginx](https://hub.docker.com/_/nginx)

`docker pull nginx`

`docker run --name demo-nginx -d -p 8080:80 nginx`

## Publish

`docker build -f Nginx\Dockerfile -t demodockercompose.nginx .`

`docker build -f DemoDockerCompose.FirstApp\Dockerfile -t demodockercompose.first .`

`docker build -f DemoDockerCompose.SecondApp\Dockerfile -t demodockercompose.second .`

`docker compose -p demodockercompose -f publish.yml up -d`

# Other

`docker cp <source> <container>:<target>`

