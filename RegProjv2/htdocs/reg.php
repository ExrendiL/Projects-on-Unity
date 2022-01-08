<?php
  // Здесь ничего не менялось
  $db = 'unity-project';
  $login = 'root';
  $pass = 'root';
  $host = 'localhost';

  $dsn = 'mysql:host=' . $host . ';dbname=' . $db;
  $pdo = new PDO($dsn, $login, $pass);

  if(!$pdo) {
    echo "Мы не подключились";
    exit();
  }

  $name = $_POST['name'];
  $login = $_POST['login'];
  $pass = md5($_POST['pass'].'sdkF&*hkg234sdf');

  $query = $pdo->prepare('INSERT INTO users(name, login, password) VALUES(:name, :login, :password)');
  $query->execute(['name' => $name, 'login' => $login, 'password' => $pass]);
