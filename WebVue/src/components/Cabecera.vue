<template>
  <header>
      <nav class="header">
          <div class="left">
              <img src="../../multimedia/logosinletra.svg" class="logocine">
          </div>
          <ul class="right">
              <li><a href="index.html" class="promo">Promos</a></li>
              <li><a href="index.html" class="pelis">Películas</a></li>
              <li><a href="index.html" class="billetes">Boletos</a></li>
          </ul>
      </nav>
  </header>
</template>

<style>
.header {
  background-color: rgb(196, 0, 0);
  height: auto;
  display: flex;
  flex-wrap: wrap; 
  justify-content: space-between;
  align-items: center;
  font-family: 'Helvetica';
}

.logocine {
  height: 60px; 
}

.right {
  display: flex;
  flex-direction: row;
  justify-content: center;
  list-style: none;
  font-size: 20px;
  flex-wrap: wrap;
  margin: 0;
}

.right a {
  color: white;
  text-decoration: none; 
}

.promo,
.pelis,
.billetes {
  margin: 10px; 
}

.left,
.right {
  margin: 20px;
}

@media (max-width: 768px) {
  .header {
    justify-content: center; 
  }

  .right {
    justify-content: center;
    font-size: 14px; 
  }

  .promo, .pelis, .billetes {
    margin: 0 10px; 
  }
}
</style>