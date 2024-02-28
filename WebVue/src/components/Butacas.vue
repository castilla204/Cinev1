<template>
  <div class="contenedor">
    <h2 class="titulo">Seleccione sus butacas</h2>
    <div class="contenedorButacas">
      <div v-for="(fila, index) in filas" :key="index" class="fila">
        <svg
          v-for="butaca in fila"
          :key="butaca.id"
          :id="'butaca-' + butaca.id"
          @click="comprobarButaca(butaca.id)"
          :class="{'ocupada': butaca.ocupada, 'seleccionada': butacaSeleccionada.includes(butaca.id)}"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 24 24"
          width="100"
          height="100"
        >
          <path d="M0 0h24v24H0z" fill="none"/>
          <path fill="#f4c242" d="M7 10h10v4H7z"/>
          <path fill="#f48f42" d="M7 8h10v2H7z"/>
          <path fill="#f4af42" d="M4 9h3v6H4zM17 9h3v6h-3z"/>
        </svg>
      </div>
      <button @click="realizarReserva" :disabled="butacaSeleccionada.length === 0" class="botonReserva">Reservar</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed, ref } from 'vue';
import { ButacaStore } from '../store/ButacaStore';
import { useReservaStore } from '../store/ReservaStore';
import { useRouter } from 'vue-router'; 

export default defineComponent({
  props: {
    sesionID: {
      type: Number,
      required: true
    }
  },
  setup(props) {
    const butacaStore = ButacaStore();
    const reservaStore = useReservaStore();
    const butacas = computed(() => butacaStore.butacas);
    const butacaSeleccionada = ref<number[]>([]);
    const router = useRouter(); 

    const filas = computed(() => {
      const resultado = [];
      for (let i = 0; i < butacas.value.length; i += 10) {
        resultado.push(butacas.value.slice(i, i + 10));
      }
      return resultado;
    });

    onMounted(async () => {
      await butacaStore.cargarButacas(props.sesionID);
    });

    const comprobarButaca = (id: number) => {
      const butaca = butacas.value.find(b => b.id === id);
      if (butaca && !butaca.ocupada) {
        const index = butacaSeleccionada.value.indexOf(id);
        if (index === -1) {
          butacaSeleccionada.value.push(id);
        } else {
          butacaSeleccionada.value.splice(index, 1);
        }
      }
    };

    const realizarReserva = async () => {
      try {
        await reservaStore.realizarReserva({
          sesionID: props.sesionID,
          usuarioID: 1,
          butacasIds: butacaSeleccionada.value
        });
        router.push({ name: 'PaginaPago', params: { sesionID: props.sesionID.toString() } });
      } catch (error) {
        console.error('Error al realizar la reserva:', error);
      }
    };

    return {
      filas,
      comprobarButaca,
      realizarReserva,
      butacaSeleccionada
    };
  }
});
</script>

<style scoped>
.contenedor {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.contenedorButacas {
  background-color: #f0f0f0;
  border-radius: 15px;
  padding: 20px;
  box-shadow: 0 8px 16px rgba(0, 0, 0, 0.1);
  margin-top: 20px;
}

.titulo {
  font-size: 1.8rem;
  color: #ffffff;
  margin-bottom: 10px;
  font-family: 'Helvetica';
 margin-top: 15px;
}

.fila {
  display: flex;
}

.butaca {
  margin: 5px;
  cursor: pointer;
}

.botonReserva {
  background-color: #4CAF50;
  color: white;
  padding: 15px 32px;
  text-align: center;
  font-size: 16px;
  margin-top: 20px;
  border: none;
  border-radius: 10px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}
.ocupada path {
  fill: red ; /* Importante para sobrescribir otros colores */
  opacity: 20%;
}

.seleccionada path {
  fill: blue;
  opacity: 20%;
}

.botonReserva:hover {
  background-color: #45a049;
}
</style>