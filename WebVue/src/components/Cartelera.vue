<template>
    <div id="ticketForm">
      <h1 class="titulocartelera">CARTELERA</h1>
      <p class="subtitulo1cartelera">CINE PARA TODA LA FAMILIA</p>
      <div class="linearoja"></div>
      <div class="contenedorpeliculas" id="contenedorpeliculas">
        <!-- Cargar las primeras 5 películas -->
        <div class="movie-group">
          <img v-for="(movie, index) in primeraFila" :key="movie.peliculaID" :src="'multimedia/' + movie.imagen" :alt="movie.titulo" @click="RedirigirInfopeli(movie.peliculaID)" class="movie-image rounded-image">
        </div>


        <!-- Mostrar el subtitulo si hay mas de 5 peliculas -->
        <div v-if="CargarSubtitulo" class="subtitulo-group">
          <p class="subtitulo1cartelera">NUEVAS PELÍCULAS</p>
          <div class="linearoja"></div>
        </div>
        <!-- Cargar la segunda fila -->
        <div class="movie-group">
          <img v-for="(movie, index) in segundaFila" :key="movie.peliculaID" :src="'multimedia/' + movie.imagen" :alt="movie.titulo" @click="RedirigirInfopeli(movie.peliculaID)" class="movie-image rounded-image">
        </div>
      </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from 'vue';
import { PeliculasStore } from '../store/index'; 
import { useRouter } from 'vue-router';

export default defineComponent({
  setup() {
    const router = useRouter();
    const moviesStore = PeliculasStore();

    onMounted(() => {
      moviesStore.ObtenerPeliculas();
    });

    const CargarSubtitulo = computed(() => {
      return moviesStore.peliculas.length > 5;
    });

    return {
      primeraFila: computed(() => moviesStore.peliculas.slice(0, 5)),
      segundaFila: computed(() => moviesStore.peliculas.slice(5)),
      isLoading: computed(() => moviesStore.isLoading),
      CargarSubtitulo,
      RedirigirInfopeli: (movieId: number) => {
        router.push({ name: 'InfoPelicula', query: { movieId: movieId.toString() } });
      },
    };
  },
});
</script>

<style scoped>
.cartelera {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: 80px;
}

.titulocartelera {
  font-size: 20px;
  margin-left: 10%;
  color: white;
  text-align: left;
}

.subtitulo1cartelera {
  font-family: 'HelveticaThin';
  margin-left: 10%;
  color: white;
  text-align: left;
  font-size: 20px; 
  margin-bottom: 0%;
}

.linearoja {
  margin-left: 10%;
  width: 80%;
  height: 6px;
  background-color: darkred;
}

.contenedorpeliculas img {
  width: 13%;
  margin: 30px;
}

.rounded-image {
  border-radius: 10px;
}

#ticketForm {
  width: 100%;
  text-align: center;
}
</style>