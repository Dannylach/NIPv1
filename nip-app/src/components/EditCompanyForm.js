import React, { PropTypes } from 'react';
import {editCompany} from './../modules/onCompaniesOperations';
import {validateRegon, validateNip} from './../utilities/validateNumber';

class EditCompanyForm extends React.Component {
	constructor(props) {
	    super(props);
    	this.state = {
            company: '',
            Nip: '',
            Krs: '',
            Regon: '',
            Name: '',
            Street: '',
            HouseNumber: '',
            PostalCode: '',
            City: '',
            Rating: '',
			isValid: 'true'
        };
  	}

    componentWillMount() {
        this.setState({
            company: this.props.company,
            Nip: this.props.company.Nip,
            Krs: this.props.company.Krs,
            Regon: this.props.company.Regon,
            Name: this.props.company.Name,
            Street: this.props.company.Street,
            HouseNumber: this.props.company.HouseNumber,
            PostalCode: this.props.company.PostalCode,
            City: this.props.company.City,
            Rating: this.props.company.Rating
        })
    }

    componentWillReceiveProps(nextProps) {
        if(this.state.company != nextProps.company) {
            this.setState({
                Nip: nextProps.company.Nip,
                Krs: nextProps.company.Krs,
                Regon: nextProps.company.Regon,
                Name: nextProps.company.Name,
                Street: nextProps.company.Street,
                HouseNumber: nextProps.company.HouseNumber,
                PostalCode: nextProps.company.PostalCode,
                City: nextProps.company.City,
                Rating: nextProps.company.Rating
            })
        }
    }

    handleChangeAndValidation = (event) => {
        if(validateNip(event.target.value) || validateRegon(event.target.value)) this.setState({ isValid: true})
    	    this.setState({[event.target.name]: event.target.value })
    }

  	handleChange = (event) => {
    	this.setState({[event.target.name]: event.target.value})
  	}

  	handleSubmit = (event) => {
    	event.preventDefault();
    	var isValidNip = validateNip(this.state.Nip)
        var isValidRegon =  validateRegon(this.state.Regon);

        if(isValidNip = undefined) this.setState({ isValid: false});
	    var {Nip, Krs, Regon, Name, Street,
            HouseNumber, PostalCode, City, Rating} = this.state;

        if(isValidNip || isValidRegon) {
            const { onSendingData, onSearchingCompany } = this.props;
		    onSendingData();
    	    editCompany({ Nip: Nip,
                Krs: Krs,
                Regon: Regon,
                Name: Name,
                Street: Street,
                HouseNumber: HouseNumber,
                PostalCode: PostalCode,
                City: City,
                Rating: Rating})
            .then(result => {
                localStorage.removeItem(this.props.searchedNumber),
                onSearchingCompany(result.result)
            });
        }
  	}

  	render() {
        var { isValid } = this.state;
        const company = this.state;
       
        return (
            <div className='editForm'>
                <form onSubmit={this.handleSubmit}>
                    <span>Firma do edycji:</span>
                    <table>
                        <tr>
                        <td className="nonPadding">NIP</td>
                        <td className="bottomPadding"><input type="text"
                            name="Nip"
                            value={company.Nip}
                            onChange={this.handleChangeAndValidation}
                            title = "Poprawny format: 777-777-77-77; PL7777777777; 7777777777."
                            pattern="[A-Za-z]{0,3}[0-9]{10}|[0-9]{3}[-][0-9]{3}[-][0-9]{2}[-][0-9]{2}|Nieznany numer NIP."/>
                        </td>
                        </tr><tr>
                            <td className="nonPadding">KRS</td>
                            <td className="bottomPadding"><input type="text"
                                name="Krs"
                                value={company.Krs}
                                title = "Wprowadź poprawny numer KRS."
                                pattern="[0-9]{10}|[KRS][0-9]{10}"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">REGON</td>
                            <td className="bottomPadding"><input type="text"
                                name="Regon"
                                value={company.Regon}
                                title = "Wprowadź poprawny numer REGON."
                                pattern="[0-9]{7}|[0-9]{14}|[0-9]{9}|Nieznany numer REGON."
                                onChange={this.handleChangeAndValidation}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">Name</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.Name}
                                name="Name"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">Street</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.Street}
                                name="Street"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">House Number</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.HouseNumber}
                                title="To nie jest numer."
                                pattern="[0-9]*"
                                name="HouseNumber"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">City</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.City}
                                name="City"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">Postal Code</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.PostalCode}
                                name="PostalCode"
                                title="Proszę podać kod pocztowy w formacie 00-000."
                                pattern="[0-9]{2}[-][0-9]{3}"
                                onChange={this.handleChange}/>
                            </td>
                        </tr><tr>
                            <td className="nonPadding">Rating</td>
                            <td className="bottomPadding"><input type="text"
                                value={company.Rating}
                                name="Rating"
                                title="Prowszę wprowadzić wartość od 0 do 5."
                                pattern="[0-5]"
                                onChange={this.handleChange}/>
                            </td>
                        </tr>
                    </table>
                    {!isValid && 'Błędne dane (NIP, KRS lub REGON), proszę sprawdź wprowadzone dane i spróbuj raz jeszcze'}
                    {isValid && <span className="smallerSpan"><input type="submit" value="Zatwierdź zmiany." /></span>}
                </form>
            </div>
        );
  	}
}

EditCompanyForm.propTypes = {
    onAskingForData: PropTypes.func,
  	onSendingData: PropTypes.func,
    onSearchingCompany: PropTypes.func,
    searchedNumber: PropTypes.string,
	company: PropTypes.shape({
		Nip: PropTypes.string,
		Krs: PropTypes.string,
		Regon: PropTypes.string,
		Name: PropTypes.string,
		Street: PropTypes.string,
		HouseNumber: PropTypes.string,
		PostalCode: PropTypes.string,
		City: PropTypes.string,
		Rating: PropTypes.number})
}

export default EditCompanyForm;