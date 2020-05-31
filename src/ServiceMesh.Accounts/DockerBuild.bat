docker build --tag servicemesh.accounts:1.2 . 

docker run servicemesh.accounts:1.2 -p 5097:80/tcp --name service.accounts.container
pause
