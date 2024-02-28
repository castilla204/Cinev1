import { defineStore } from 'pinia';

export const useUsuariosStore = defineStore({
  id: 'usuarios',
  state: () => ({
    loggedIn: false,
    currentUser: null,
  }),
  actions: {
    async login(credenciales: { correoElectronico: string; contrasena: string }) {
      try {
        const response = await fetch('http://localhost:8001/Usuario', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(credenciales),
        });
        if (response.ok) {
          const data = await response.json();
          if (data.length > 0) {
            this.loggedIn = true;
            this.currentUser = data[0];
          } else {
            console.error('Credenciales inválidas');
            throw new Error('Credenciales inválidas'); 
          }
        } else {
          console.error('Error al iniciar sesión:', response.statusText);
          throw new Error(response.statusText);
        }
      } catch (error) {
        console.error('Error al iniciar sesión:', error);
        throw error; 
      }
    },
    async register(nuevoUsuario: {
      nombre: string;
      correoElectronico: string;
      contrasena: string;
      rol: number;
    }) {
      try {
        const response = await fetch('http://localhost:8001/Usuario', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(nuevoUsuario),
        });
        if (response.ok) {
          console.log('Usuario registrado exitosamente');
        } else {
          console.error('Error al registrar usuario:', response.statusText);
          throw new Error(response.statusText); 
        }
      } catch (error) {
        console.error('Error al registrar usuario:', error);
        throw error; 
      }
    },
    logout() {
      this.loggedIn = false;
      this.currentUser = null;
    },
  },
});