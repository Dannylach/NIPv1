import React, {Component} from 'react';

class Card extends Component {

    render() {
        const card = this.props.card;
        if(card != undefined && card.id != 0) {
            return(
                <div className='card'>
                        <span className="nonPadding">Company Name: {card.Name}</span>
                        <span className="nonPadding">Street: {card.Street} {card.HouseNumber}</span>
                        <span className="nonPadding">City: {card.City}</span>
                        <span className="nonPadding">Postal Code: {card.PostalCode}</span>
                        <span className="nonPadding">KRS: {card.Krs}</span>
                        <span className="nonPadding">NIP: {card.Nip}</span>
                        <span className="nonPadding">REGON: {card.Regon}</span>
                        <span className="nonPadding">Rating: {card.Rating}</span>
                </div>
            );
        } else {
            return(
                <div className='card'>
                    <span>Some_Error_Occurred</span>
                    <span>Please_Contact_Your</span>
                    <span>Web_Administrator</span>
                </div>
            )
        }
    }
}

export default Card;