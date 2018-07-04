import React, {Component} from 'react';

class LogsView extends Component {
    render() {
        const logsView = this.props.log;
        
        if(logsView == undefined) {
            return(
            <div>
                <p>No_logs_found</p>
            </div>
            )
        }

        return(
            <div className="card">
                Search Id: {logsView.Id} Number: {logsView.Number} Times Searched: {logsView.TimesSearched}
            </div>
        );
    }
}

export default LogsView;