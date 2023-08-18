import Header from "./Header"
import SearchBar from "./SearchBar"
import SearchState from "./SearchState"

function App() {
  return (
    <>

      <div>
        <Header></Header>
      </div>

      <div>
        <SearchState></SearchState>
      </div>
      <div className="search-form flex items-center justify-center min-h-screen">
        <SearchBar className="w-4/5"></SearchBar>
      </div>
    </>
  )
}

export default App
