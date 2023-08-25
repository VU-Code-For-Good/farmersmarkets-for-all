caddy stop

docker stop cfa-farmers-backend
docker rm cfa-farmers-backend
docker run -d -p 8080:80 --name cfa-farmers-backend ghcr.io/vu-code-for-good/farmersmarkets-for-all-backend:main

docker stop cfa-farmers-frontend
docker rm cfa-farmers-frontend
docker run -d -p 8090:80 --name cfa-farmers-frontend ghcr.io/vu-code-for-good/farmersmarkets-for-all-frontend:main

caddy start