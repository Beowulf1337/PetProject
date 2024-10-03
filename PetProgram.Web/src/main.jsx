import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import './index.css'

// create the root of the app and render the App component within StrictMode
createRoot(document.getElementById('root')).render(

   /* Wrap the app in StrictMode for highlighting issues */
  <StrictMode>

    {/* Render the main App component */}
    <App />
  </StrictMode>,
)
