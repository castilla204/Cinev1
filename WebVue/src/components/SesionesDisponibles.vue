<template>
  <div class="sesiones-container">
    <h1 id="titulosesiones">Sesiones Disponibles</h1>
    <div v-for="(sesion, index) in sessions" :key="sesion.sesionID" class="sesion" :style="{ backgroundColor: sessionColors[index % sessionColors.length] }" @click="redirigirReserva(sesion.sesionID)">
      <div class="sesion-info" >
        <p>{{ sesion.fechaHora }}</p>
        <p>{{ sesion.nombreSala }}</p>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, watch } from 'vue';
import { SesionesStore } from '../store/SesionStore';
import { useRouter } from 'vue-router'; // Importa el enrutador

const router = useRouter(); // Obtiene el enrutador

const almacenSesiones = SesionesStore();
const sessions = ref([]);

watch(() => almacenSesiones.sessions, (newSessions) => {
  sessions.value = newSessions;
});

const sessionColors = ['#9E2A2B', '#A93226', '#AF601A', '#B9770E', '#C68407', '#D4AC0D'];
const redirigirReserva = (sesionID) => {
  router.push({ name: 'Butacas', params: { sesionID: sesionID.toString() } });
};
</script>

<style scoped>
.sesiones-container {
  flex-direction: column;
  align-items: center;
}
#titulosesiones{
  font-family: 'Helvetica';
}
.sesion {
  cursor: pointer; /* Cambia el cursor al pasar sobre las sesiones para indicar que son clicables */
  margin-bottom: 20px;
  border-radius: 10px;
  border: 1px solid #ccc;
  padding: 10px;
  width: 300px;
  font-family: 'HelveticaThin';
}

.sesion-info {
  display: flex;
  justify-content: space-between;
}
</style>