<?php
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

  $login = $_POST['login'];
  $pass = md5($_POST['pass'].'sdkF&*hkg234sdf');

  $query = $pdo->query("SELECT * FROM `users` WHERE `login` = '$login' AND `password` = '$pass'")->fetchColumn();
  if($query == 0)
    echo "Пользователь не найден";
  else
    echo "Done";
