import APITest from "./APITest"
import Header from "./Header"
import SearchBar from "./SearchBar"
import StateDirectory from "./StateDirectory/StateDirectory"



function App() {
  return (
    <>

      <div>
        <Header></Header>
      </div>

      <div>
        <StateDirectory></StateDirectory>
      </div>

      <div>
        <APITest></APITest>
      </div>

      <div className="search-form flex items-center justify-center min-h-screen">
        <SearchBar className="w-4/5"></SearchBar>
      </div>
    </>
  )
}

export default App
