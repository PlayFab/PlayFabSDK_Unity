Instructions:
The test app can be used for manual testing of the Party SDK. Below I'll explain my flow for testing:

Basic connection:
1. Build a version of the client you are trying to test (eg. build standalone for Win32, or GameCore for Xbox / Win10)
2. In the editor, press play.
3. Click the 'Create & Join' button. This will populate a Network ID in the textbox above the button.
4. Copy and paste the Network ID from the text box and paste it into the text box of your second client.
5. Press the 'Join' button on your second client.
6. Now you should see a visualization of the player under the "Create & Join" button.
7. You can press the 'Leave' button to leave the network and press the "Join" button to join whatever Network ID is in the textbox.

Chat:
1. Follow the steps for "Basic Connection" above.
2. Under the "Chat messages" heading, enter text in the textbox.
3. Hit the "Send" button to send the message.
4. If chat permissions are set properly, you will see the chat message in the "Chat messages" section of the other client.

Data Messages:
1. Follow the steps for "Basic Connection" above.
2. Under the "Data messages" heading, enter text in the textbox.
3. Hit the "Send" button to send the message.
4. You will see the data message show up in the "Data messages" section of the other client.