import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import MarketsListPage from './MarketsListPage'
import './styles.css'
import { render } from "react-dom";
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

render(  <RouterProvider router={router} />, document.getElementById("root"));
