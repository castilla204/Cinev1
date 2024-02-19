<template>
  <div class="general" v-if="pelicula">
    <div id="movieDetails" class="movieDetails">
      <!-- Div para la informacion de lka pelicula -->
      <div class="text-container">
        <img v-if="pelicula.imagen" :src="`multimedia/${pelicula.imagen}`" class="image" :alt="pelicula.titulo">
      </div>
      <div class="text-container">
        <h1 id="movieTitle">{{ pelicula.titulo }}</h1>
        <p id="movieDescription">{{ pelicula.descripcion }}</p>
      </div>
      <button id="boton">Comprar</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';

export default defineComponent({
  setup() {
    const pelicula = ref(null);
    const isLoading = ref(false);
    const route = useRoute();

    const CargaPelicula = async () => {
      isLoading.value = true;
      try {
        const IdPelicula = route.query.movieId;
        const response = await fetch(`http://localhost:8001/Pelicula/${IdPelicula}`);
        pelicula.value = await response.json();
      } catch (error) {
        console.error(error);
      } finally {
        isLoading.value = false;
      }
    };

    onMounted(CargaPelicula);
    return { pelicula, isLoading };
  },
});
</script>



<style scoped>
a {
  text-decoration: none;
  color: white;
  transition: transform 0.2s ease-in-out;
}

a:hover {
  transform: scale(1.1);
}

.left,
.right {
  margin: 20px 40px;
}


.general{
  display: flex;
  flex-direction: column;
  min-height: 100vh; 
  background-color: black; 
}

body {
  font-family: "HelveticaThin";
  margin: 0;
  background-color: black;
  background-size: contain;
  background-position: right;
  background-attachment: fixed;
  background-repeat: no-repeat;
}

.text-container {
  max-width: 50%;
  color: rgb(255, 255, 255);
  font-size: 25px;
  margin-top: 200px;
  margin-left: 300px;
  overflow-wrap: break-word;
}

.h1 {
  font-family: "HelveticaBold";
}

.image {
  position: relative;
  overflow: hidden;
  border-radius: 10px; 
  width: 100%;
  height: auto;
}

.image::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(to left, rgba(0, 0, 0, 0) 50%, rgb(0, 0, 0) 100%);
}

#boton {
  margin-top: 80px;
  margin-left: 300px;
  padding: 20px 50px;
  border-radius: 100px;
  background-color: red;
  color: white;
  font-size: 18px;
}


@media screen and (max-width: 767px) {
  /* HEADER*/
  body {
    text-align: center;
    background: none;
    background-color: rgb(255, 255, 255);
  }
  .left,
  .right {
    margin: 10px;
  }
  .header {
    flex-direction: column;
    align-items: center;
    height: auto;
  }
  .logocine {
    display: none;
  }
  .izquierda {
    display: none;
  }
  .right {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    list-style: none;
    color: white;
    font-size: 20px;
    margin-right: 8%;
    margin-top: 10px;
    text-align: center;
  }
  .right ul {
    padding: 0;
    margin: 0;
  }
  .right li {
    margin: 10px;
  }
  .text-container {
    color: rgb(255, 255, 255);
    margin-top: 30%;
    margin-left: 300px;
  }
  .rigth {
    font-family: "Helvetica";
  }
  body {
    margin: 0;
    padding: 0;
    background-image: none;
    background-color: black;
  }
  .text-container {
    max-width: 100%;
    font-size: 16px;
    margin-left: 10px;
  }
  #boton {
    margin-left: 10px;
    padding: 10px 20px;
    margin-top: 10px;
  }
  .text-container {
    color: rgb(255, 255, 255);
    margin-top: 30%;
    margin-left: 300px;
  }
  body {
    margin: 0;
    padding: 0;
    background-image: none;
    background-color: black;
  }
  .text-container {
    font-family: "Helvetica";
    margin-top: 20%;
    max-width: 100%;
    font-size: 16px;
    margin-left: 10px;
  }
  #boton {
    margin-left: 10px;
    padding: 10px 20px;
    margin-top: 10px;
  }
  .image {
    display: none; 
  }
}
</style>