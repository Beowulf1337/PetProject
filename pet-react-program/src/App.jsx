import React from 'react'
import './App.css'
import Pet from './components/Pet.jsx' 

function App() {
  return (
    <>
      <div>
        <h1>Random Pet Generator</h1>
        <Pet /> {/* Add the Pet component here */}
      </div>
    </>
  )
}

export default App

