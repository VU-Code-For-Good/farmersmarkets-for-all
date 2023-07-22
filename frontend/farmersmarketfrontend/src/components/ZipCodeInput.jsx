import React from "react";

export default class ZipCodeInput extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      zipCode: ""
    };
  }

  handleZipCodeChange = (event) => {
    // Ensure only numeric characters are allowed
    const zipCode = event.target.value.replace(/\D/, "");

    // Limit the input to 5 digits
    if (zipCode.length > 5) {
      return;
    }

    this.setState({
      zipCode
    });

    // Check if the entered ZIP code is valid (5 digits)
    if (zipCode.length === 5) {
      // Emit a custom "ready-zipcode" event with the valid ZIP code value
      const readyZipCodeEvent = new CustomEvent("ready-zipcode", {
        detail: {
          zipCode
        }
      });

      // Dispatch the event to be caught by the parent component
      document.dispatchEvent(readyZipCodeEvent);
    }
  };

  render() {
    return (
      <div className="p-4 flex-1">
        <label className="block text-gray-700 text-sm font-bold mb-2">
          Enter Zip Code:
        </label>
        <input
          type="text"
          className="appearance-none w-full bg-white border border-gray-300 text-gray-700 py-3 px-4 pr-8 rounded leading-tight focus:outline-none focus:border-blue-500"
          placeholder="Enter your zip code"
          value={this.state.zipCode}
          onChange={this.handleZipCodeChange}
        />
      </div>
    );
  }
}
