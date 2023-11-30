import React from 'react'
//aca todos los import da cada pagina
const Dashboard = React.lazy(() => import('./views/dashboard/Dashboard'))
const Usuarios = React.lazy(() => import('./views/usuarios/usuarios'))
const Empleados = React.lazy(() => import('./views/empleados/empleados'))
const Sucursales = React.lazy(() => import('./views/sucursales/sucursales'))
const Reporte = React.lazy(() => import('./views/reporte/reporte'))
const Home = React.lazy(() => import('./views/Home/home'))


const routes = [
  //aca van todas las rutas como tal
  { path: '/', exact: true, name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', element: Dashboard },
  { path: '/usuarios', name: 'Usuarios', element: Usuarios },
  { path: '/empleados', name: 'Empleados', element: Empleados },
  { path: '/sucursales', name: 'Sucursales', element: Sucursales },
  { path: '/reporte', name: 'Reporte', element: Reporte },
  { path: '/home', name: 'Home', element: Home },
]

export default routes
