# AWS Integration Documentation

## Overview
This document provides detailed information on how AWS services are integrated into the Cosmic Trails project. It includes instructions for setting up and running AWS Lambda functions using the Serverless Framework.

## Prerequisites
Before you begin, ensure you have the following:
- An AWS account
- AWS CLI installed and configured
- Node.js and npm installed
- Serverless Framework installed globally

## AWS Lambda
AWS Lambda is used to handle serverless functions for the game. The `lambda_function.py` file contains the code for the Lambda function.

### Lambda Function
The Lambda function is defined in `lambda_function.py` and is deployed using the Serverless Framework.

#### Example Lambda Function
```python
import json

def lambda_handler(event, context):
    return {
        'statusCode': 200,
        'body': json.dumps('Hello from Lambda!')
    }
### Serverless Framework
The Serverless Framework is used to deploy the Lambda function. The configuration is defined in serverless.yml.

serverless.yml
The serverless.yml file defines the service, provider, and functions for the Serverless Framework.

Example serverless.yml

service: cosmic-trails

provider:
  name: aws
  runtime: python3.8
  region: us-west-2

functions:
  hello:
    handler: lambda_function.lambda_handler
    events:
      - http:
          path: hello
          method: get

Deployment Script
The deploy.sh script is used to deploy the Serverless application.

Example deploy.sh

#!/bin/bash

# Deploy the serverless application
serverless deploy

# Setup Instructions

## Install the Serverless Framework:

npm install -g serverless

### Configure AWS CLI:

Ensure your AWS CLI is configured with the necessary credentials.

aws configure

#### Navigate to the AWS Directory:
cd AWS

##### Deploy the Application:

Run the deployment script to deploy the Lambda function.

./deploy.sh

###### Testing the Lambda Function
Invoke the Lambda Function:

You can test the Lambda function using the Serverless Framework.
serverless invoke -f hello

Check the Logs:

View the logs to ensure the function is running correctly.
serverless logs -f hello