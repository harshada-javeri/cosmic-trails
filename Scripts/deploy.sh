#!/bin/bash

# Variables
FUNCTION_NAME="your-lambda-function-name"
ZIP_FILE="function.zip"
HANDLER="index.handler"
ROLE_ARN="arn:aws:iam::your-account-id:role/your-lambda-role"
RUNTIME="nodejs14.x"
REGION="us-west-2"

# Create a deployment package
zip -r $ZIP_FILE .

# Update the Lambda function code
aws lambda update-function-code \
    --function-name $FUNCTION_NAME \
    --zip-file fileb://$ZIP_FILE \
    --region $REGION

# Update the Lambda function configuration (if needed)
aws lambda update-function-configuration \
    --function-name $FUNCTION_NAME \
    --handler $HANDLER \
    --runtime $RUNTIME \
    --role $ROLE_ARN \
    --region $REGION

echo "Deployment complete."