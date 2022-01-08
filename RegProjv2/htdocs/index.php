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

  $query = $pdo->query('SELECT * FROM `users`');
  while($row = $query->fetch(PDO::FETCH_OBJ))
    echo "ID:".$row->id."|Name:".$row->name."|Login:".$row->login."|Pass:".$row->password.";";
