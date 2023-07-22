import React from 'react'
import ReactDOM from 'react-dom/client'
import './styles.css'

import {
  createBrowserRouter,
  RouterProvider
} from "react-router-dom";
import SearchPage from './SearchPage.jsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <SearchPage />
  }
])

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
