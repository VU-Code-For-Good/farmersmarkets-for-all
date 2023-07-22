import Header from "./Header"
import SearchBar from "./SearchBar"
import StateSelect from "./components/StateSelect"
import ZipCodeInput from "./components/ZipCodeInput"

function SearchPage() {
  return (
    <>
      <div>
        <Header></Header>
      </div>

      <div className="search-form flex items-center justify-center min-h-screen">
        <SearchBar className="w-4/5"></SearchBar>
      </div>
    </>
  )
}

export default SearchPage
