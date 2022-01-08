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

  // Получаем ID пользователя, которого надо удалить
  $id = $_POST['id'];

  // Выполняем команду удаления и передаем ID той записи, что мы удалим
  $query = $pdo->prepare('DELETE FROM `users` WHERE `id` = :id');
  $query->execute(['id' => $id]);
