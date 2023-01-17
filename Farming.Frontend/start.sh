#!/bin/bash
sed -i "s%localhost%$APIURL%g" /usr/share/nginx/html/assets/config/production.json
nginx -g "daemon off;"
