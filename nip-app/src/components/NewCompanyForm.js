import React, { PropTypes } from 'react';
import {addCompany} from './../modules/onCompaniesOperations';
import {validateNip, validateRegon} from './../utilities/validateNumber';

class NewCompanyForm extends React.Component {
	constructor(props) {
	    super(props);
    	this.state = {	Nip: '',
            Krs: '',
            Regon: '',
            Name: '',
            Street: '',
            HouseNumber: '',
            PostalCode: '',
            City: '',
            Rating: '',
			isValid: true
        };
  	}

  	handleChange = (event) => {
    	this.setState({[event.target.name]: event.target.value})
  	}

  	handleSubmit = (event) => {
    	event.preventDefault();
    	var isValidNip = validateNip(this.state.Nip)
        var isValidRegon =  validateRegon(this.state.Regon);
        var isValid = true;
        
        if(!isValidNip || !isValidRegon) {
            this.setState({ isValid: false});
            isValid = false;
        }
        var {Nip, Krs, Regon, Name, Street,
            HouseNumber, PostalCode, City, Rating} = this.state;

        if(isValid) {
            this.setState({ isValid: true });
            const { onSearchingCompany,
    			onSendingData, token } = this.props;
		    onSendingData();
    	    addCompany({ Nip: Nip,
                Krs: Krs,
                Regon: Regon,
                Name: Name,
                Street: Street,
                HouseNumber: HouseNumber,
                PostalCode: PostalCode,
                City: City,
                Rating: Rating,
                token: token})
            .then(result => {
                localStorage.clear();
                onSearchingCompany(result.result);
            });
        }
  	}

  	render() {
        var { isValid } = this.state;

    	return (
      		<div className='addForm'>
      			<form onSubmit={this.handleSubmit}>
          			<span>
                      Wpisz dane nowej firmy:
        			</span>
                    <table>
                        <tr>
                            <td>NIP:</td>
                            <td>
                                <input type="text"
                                    name="Nip"
                                    value={this.state.Nip}
                                    onChange={this.handleChange}
                                    title = "Poprawny format: 777-777-77-77; PL7777777777; 7777777777."
                                    pattern="[A-Za-z]{0,3}[0-9]{10}|[0-9]{3}[-][0-9]{3}[-][0-9]{2}[-][0-9]{2}"/>
                            </td>
                        </tr>
                        <tr>
                            <td>KRS:</td>
                            <td>
                                <input type="text"
                                    name="Krs"
                                    value={this.state.Krs}
                                    title = "Wprowadź poprawny numer KRS."
                                    pattern="[0-9]{10}|[KRS][0-9]{10}"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>REGON:</td>
                            <td>
                                <input type="text"
                                    name="Regon"
                                    value={this.state.Regon}
                                    title = "Wprowadź poprawny numer REGON."
                                    pattern="[0-9]{7}|[0-9]{14}|[0-9]{9}"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>Name:</td>
                            <td>
                                <input type="text"
                                    value={this.state.Name}
                                    name="Name"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>Street:</td>
                            <td>
                                <input type="text"
                                    value={this.state.Street}
                                    name="Street"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>House Number:</td>
                            <td>
                                <input type="text"
                                    value={this.state.HouseNumber}
                                    title="To nie jest numer."
                                    pattern="[0-9]*"
                                    name="HouseNumber"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td>
                                <input type="text"
                                    value={this.state.City}
                                    name="City"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>Postal Code:</td>
                            <td>
                                <input type="text"
                                    value={this.state.PostalCode}
                                    name="PostalCode"
                                    title="Proszę podać kod pocztowy w formacie 00-000."
                                    pattern="[0-9]{2}[-][0-9]{3}"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                        <tr>
                            <td>Rating:</td>
                            <td>
                                <input type="text"
                                    value={this.state.Rating}
                                    name="Rating"
                                    title="Prowszę wprowadzić wartość od 0 do 5."
                                    pattern="[0-5]"
                                    onChange={this.handleChange}/>
                            </td>
                        </tr>
                    </table>
                    <span className="bottomPadding">
                        <span className="errorWithNumber">
                            {!isValid && 'Błędne dane, proszę sprawdzić wprowadzone dane i spróbuj raz jeszcze'}
                        </span>
                    </span>
        			<span className="bottomPadding"><input type="submit" value="Dodaj" /></span>
    			</form>
      		</div>
    	);
  	}
}

NewCompanyForm.propTypes = {
	onSearching: PropTypes.func,
    onSearchingCompany: PropTypes,
  	onSendingData: PropTypes.func,
    token: PropTypes.string
}

export default NewCompanyForm;