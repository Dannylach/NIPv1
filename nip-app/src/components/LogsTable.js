import React, {Component} from 'react';
import LogsView from './LogsView';

class LogsTable extends Component {
    render() {
        var counterOfLogs = 0;
        var logs = this.props.logs.Result.map((log) => {
            counterOfLogs+=1;
            return <LogsView log={log}
                key={log.id}/>
        });
        
        if(counterOfLogs<4){
            return(
                <div className="app">
                    {logs}
                </div>
            );
        } else {
            return(
                <div className="appscroll">
                    {logs}
                </div>
            );
        }
    }
}

export default LogsTable;