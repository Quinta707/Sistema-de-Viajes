import axios from 'axios';
import ApiUrl from "global";

function LoginService() {
    const baseURL = ApiUrl;

    const axiosInstance = axios.create({
        baseURL: baseURL,
    });

    const user = JSON.parse(localStorage.getItem('user'));

    async function IniciarSesion(user, data) {
        try {
            let datos = {
                "usua_Nombre": user['user'],
                "usua_Contrasenia": data['password'],
            }
            const res = await axios.post(`${baseURL}Usuarios/Login`, datos)
            if (res.data) {
                return 1
            } else {
                return 0
            }
        } catch (error) {
            return error
        }

    }

    return {
        IniciarSesion,
    };
}

export default LoginService;