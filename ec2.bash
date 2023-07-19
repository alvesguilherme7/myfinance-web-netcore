#!/bin/bash
yum update -y
yum install -y httpd
systemctl start httpd
systemctl enable httpd
MEUIP=$(curl ifconfig.me)
echo '<center><h1>Estou na instância de IP' $MEUIP '</h1></center>' > /var/www/html/index.html