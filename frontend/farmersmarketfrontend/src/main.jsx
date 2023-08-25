import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import MarketsListPage from './MarketsListPage'
import './styles.css'

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
  },
  {
    path: "/listmarkets/",
    element: <MarketsListPage/>
  }
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
)
