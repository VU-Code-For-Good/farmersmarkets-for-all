import React from "react";
import StateSelect from "./components/StateSelect";
import ZipCodeInput from "./components/ZipCodeInput";

class SearchBar extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      searchOption: "byState",
      isZipCodeReady: false,
      isStateReady: false,
      zipCode: "",
      state: ""
    };
  }

  handleSearchOptionChange = (event) => {
    this.setState({
      isZipCodeReady: false,
      isStateReady: false,
      searchOption: event.target.value,
    });
  };

  handleReadyZipCode = (event) => {
    //Get the zip code from the event
    const zipCode = event.detail.zipCode;
    this.setState({isZipCodeReady: true, zipCode: zipCode})
  };

  handleReadyState = (event) => {
    //Get the state from the event
    const state = event.detail.state;

    //Set the component state with the state
    this.setState({isStateReady: true, state: state})
  };

  componentDidMount() {
    //listen for the "ready-state" event
    document.addEventListener("ready-state", this.handleReadyState);

    //listen for the "ready-zipcode" event
    document.addEventListener("ready-zipcode", this.handleReadyZipCode);
  }

  componentWillUnmount() {
    //remove the event listeners
    document.removeEventListener("ready-state", this.handleReadyState);
    document.removeEventListener("ready-zipcode", this.handleReadyZipCode);
  }

  render() {
    const { searchOption, isZipCodeReady, isStateReady, zipCode, state } = this.state;
    const isSubmitReady = isZipCodeReady || isStateReady;

    return (
      <div className="mx-8 w-full">
        <div className="flex items-center justify-end rounded-md p-2">
          
          {searchOption === "byState" ? (
            <StateSelect className="flex-1 mr-2" />
          ) : (
            <ZipCodeInput className="flex-1 mr-2" />
          )}
          <button className={`mt-6 bg-blue-500 text-white px-4 py-2 rounded-md ${!isSubmitReady ? "opacity-50 cursor-not-allowed" : ""}`} disabled = {!isSubmitReady}>
            Search
          </button>
        </div>

        <div className="mt-4 flex items-center justify-end">
          <label className="inline-flex items-center">
            <input
              type="radio"
              name="searchOption"
              value="byState"
              checked={searchOption === "byState"}
              onChange={this.handleSearchOptionChange}
              className="form-radio h-5 w-5 text-blue-600"
            />
            <span className="ml-2 text-gray-700">By State</span>
          </label>
          <label className="inline-flex items-center ml-6">
            <input
              type="radio"
              name="searchOption"
              value="byZipcode"
              checked={searchOption === "byZipcode"}
              onChange={this.handleSearchOptionChange}
              className="form-radio h-5 w-5 text-blue-600"
            />
            <span className="ml-2 text-gray-700">By Zipcode</span>
          </label>
        </div>
      </div>
    );
  }
}

export default SearchBar;
