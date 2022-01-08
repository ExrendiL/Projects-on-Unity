<?php
  // Изменения описаны комментариями
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

  // Получаем ID нужной записи
  $id = $_POST['id'];

  // Обращаемся к БД и получаем запись по её ID
  $query = $pdo->query("SELECT * FROM `users` WHERE `id` = $id");
  while($row = $query->fetch(PDO::FETCH_OBJ))
    // Выводим пользователя точно также как на главной странице
    echo "ID:".$row->id."|Name:".$row->name."|Login:".$row->login."|Pass:".$row->password;
