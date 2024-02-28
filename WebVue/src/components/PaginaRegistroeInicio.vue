<template>
    <div class="auth-container">
      <div v-if="!loggedIn">
        <h2>Iniciar sesión</h2>
        <form @submit.prevent="handleLogin">
          <input type="email" v-model="loginData.correoElectronico" placeholder="Correo electrónico" required>
          <input type="password" v-model="loginData.contrasena" placeholder="Contraseña" required>
          <button type="submit">Iniciar sesión</button>
        </form>
      </div>
      <div v-else>
        <p>Bienvenido, {{ currentUser.nombre }}</p>
        <button @click="logout">Cerrar sesión</button>
      </div>
      <div>
        <h2>Registrarse</h2>
        <form @submit.prevent="handleRegister">
          <input type="text" v-model="registerData.nombre" placeholder="Nombre" required>
          <input type="email" v-model="registerData.correoElectronico" placeholder="Correo electrónico" required>
          <input type="password" v-model="registerData.contrasena" placeholder="Contraseña" required>
          <input type="number" v-model="registerData.rol" placeholder="Rol" required>
          <button type="submit">Registrarse</button>
        </form>
      </div>
    </div>
  </template>
  
  <script setup>
  import { ref } from 'vue';
  import { useUsuariosStore } from '../store/UsuarioStore';
  
  const usuariosStore = useUsuariosStore();
  const { loggedIn, currentUser, login, register, logout } = usuariosStore;
  
  const loginData = ref({
    correoElectronico: '',
    contrasena: ''
  });
  
  const registerData = ref({
    nombre: '',
    correoElectronico: '',
    contrasena: '',
    rol: 0
  });
  
  const handleLogin = async () => {
    try {
      await login(loginData.value);
    } catch (error) {
      alert('Error al iniciar sesión: ' + error.message);
    }
  };
  
  const handleRegister = async () => {
    try {
      await register(registerData.value);
    } catch (error) {
      alert('Error al registrar: ' + error.message);
    }
  };
  </script>
  
  <style scoped>
  .auth-container {
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  </style>