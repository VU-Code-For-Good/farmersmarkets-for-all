caddy stop
docker stop cfa-farmers-backend
docker rm cfa-farmers-backend
docker run -d -p 8080:80 --name cfa-farmers-backend ghcr.io/vu-code-for-good/farmersmarkets-for-all:main
caddy start