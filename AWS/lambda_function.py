import json

def lambda_handler(event, context):
    # Example function to handle a request
    return {
        'statusCode': 200,
        'body': json.dumps('Hello from Lambda!')
    }