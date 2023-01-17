FROM node:14-alpine AS node
WORKDIR /app
COPY package.json .
COPY package-lock.json .
RUN npm ci
COPY . .

RUN node node_modules/@angular/cli/bin/ng build --prod

FROM nginx:alpine

# Set working directory to nginx asset directory

WORKDIR /usr/share/nginx/html

# Remove default nginx static assets

RUN rm -rf ./*
# Copy static assets from node stage
COPY --from=node /app/dist/farming.frontend .
COPY ./nginx-front.conf /etc/nginx/conf.d/default.conf
COPY start.sh /
RUN chmod +x /start.sh &&\
    sed -i 's/\r$//' /start.sh
ENTRYPOINT ["sh", "/start.sh"]
