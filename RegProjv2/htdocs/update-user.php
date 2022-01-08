<?php
  // Подключаем к БД
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

  // Получаем ID пользователя, которого надо обновить
  $id = $_POST['id'];
  // Также получаем имя и логин
  $name = $_POST['name'];
  $login = $_POST['login'];

  // Выполняем команду обновления и передаем имя, логин,
  // а также ID той записи, что мы обновляем
  $query = $pdo->prepare('UPDATE `users` SET `name` = :name, `login` = :login WHERE `id` = :id');
  $query->execute(['name' => $name, 'login' => $login, 'id' => $id]);
