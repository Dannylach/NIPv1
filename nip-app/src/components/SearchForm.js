import React, { PropTypes } from 'react';
import {searchCompany} from './../modules/onCompaniesOperations';
import {getLogs} from './../modules/logs';
import {updateLogs} from './../modules/logs';
import ErrorHandler from './ErrorHandler';
import {validateRegon, validateNip} from './../utilities/validateNumber';

class SearchForm extends React.Component {
	constructor(props) {
	    super(props);
    	this.state = {
			value: '',
			startTimeHolder: new Array(),
			isValid: false
		};
  	}

  	handleChange = (event) => {
		var isValidNip = validateNip(event.target.value);
		var isValidRegon = validateRegon(event.target.value);
		
		if(isValidRegon || isValidNip) {
    		this.setState({ isValid: true})
		}
		else this.setState({ isValid: false })
		this.setState({ value: event.target.value })
  	}

	handleTimeExpire = () => {
		var date = new Date();
		var startTimeHolder = this.state.startTimeHolder;
		for(var i = 0; i <= startTimeHolder.length; i++) {
			var dataFromStartTimeHolder = startTimeHolder[i];
			if(dataFromStartTimeHolder != null) {
				var timeOfFirstInput = dataFromStartTimeHolder[1];
				if((date.getTime() - timeOfFirstInput) > (1000*60)) {
					localStorage.removeItem(dataFromStartTimeHolder[0]);
					startTimeHolder.splice(i, 1);
				}
			}
		}
	}

  	handleSubmit = (event) => {
    	event.preventDefault();
		this.props.onReceiveCompanyData('pend');
    	var value = this.state.value;
		var date = new Date();
    	const localStorageData = JSON.parse(localStorage.getItem(value));
		
    	if(this.state.isValid){
			this.props.onSearchingCompany(value);
        	const { onReceiveCompanyData,
				passiveOnReceiveLogs,
				onAskingForData } = this.props;
      		if(localStorageData == undefined) {
        		onAskingForData();
        		searchCompany({ companyId: value }).then(result => {
            		onReceiveCompanyData(result);
            		localStorage.setItem(value, JSON.stringify(result));
					this.state.startTimeHolder.push([value, date.getTime()]);
            		getLogs().then(result => passiveOnReceiveLogs(result));
					this.handleTimeExpire();
          		});
      		} else {
        		onAskingForData();
        		onReceiveCompanyData(localStorageData)
				if(localStorageData.Result != undefined && localStorageData.Result.Id != 0)
        			updateLogs({ companyId: value }).then(result => passiveOnReceiveLogs(result));
				this.handleTimeExpire();
      		}
    	}
  	}

  	render() {
    	var isValid = this.state.isValid;

    	if(isValid == undefined) isValid = false;
    	var classes = isValid ? 'valid' : 'invalid';
    	
		return (
      		<div className='SearchForm'>
				<form onSubmit={this.handleSubmit}>
        			<label>
          				<span className="formField">Wpisz wyszukiwany nr REGON/NIP/KRS:</span>
          				<span className="formField"><input type="text"
                			value={this.state.value}
                			className={classes}
        	        		onChange={this.handleChange} />
        			</span></label>
        			<div className='emptySpan'>
        				<span className="errorWithNumber">
							{!isValid && <ErrorHandler errorMessage = "Please write valid number."/>}
						</span>
        			</div>
        			<span className="smallerSpan">{isValid && <input type="submit" value="Wyszukaj" />}
        			{!isValid && <input type="submit" value="Wyszukaj" disabled/>}</span>
      			</form>
      		</div>
    	);
  	}
}

SearchForm.propTypes = {
	onSearchingCompany: PropTypes.func,
	onReceiveCompanyData: PropTypes.func,
  	passiveOnReceiveLogs: PropTypes.func,
  	onAskingForData: PropTypes.func
}

export default SearchForm;